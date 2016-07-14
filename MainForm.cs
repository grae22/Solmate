/*
 * TODO
 * 
 * x Batch processing would be nice - i.e. select several solutions and clean/build
 *   them. A complication is that you need to specifiy build profiles for each.
 * x Building.
 * 
*/ 

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace SolMate
{
  public partial class MainForm : Form
  {
    //-------------------------------------------------------------------------

    private const string c_defaultVsDevEnvFilename =
      @"C:\xProgram Files (x86)\Microsoft Visual Studio 9.0\Common7\IDE\devenv.exe";

    private string VsDevEnvFilename { get; set; } = null;

    //-------------------------------------------------------------------------

    public MainForm()
    {
      InitializeComponent();

      uiClean.Enabled = false;
    }

    //-------------------------------------------------------------------------

    private void MainForm_Load( object sender, EventArgs e )
    {
      LoadSettings();
    }

    //-------------------------------------------------------------------------

    private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
    {
      SaveSettings();
    }

    //-------------------------------------------------------------------------

    private void LoadSettings()
    {
      try
      {
        RegistryKey key = Registry.CurrentUser.OpenSubKey( "Software\\SolMate" );

        if( key == null )
        {
          key = Registry.CurrentUser.CreateSubKey( "Software\\SolMate" );
        }

        // Window location.
        Point point =
          new Point(
              (int)key.GetValue( "mainFormX", 100 ),
              (int)key.GetValue( "mainFormY", 100 ) );

        Rectangle virtualScreen = SystemInformation.VirtualScreen;

        if( point.X < virtualScreen.X ||
            point.X > virtualScreen.X + virtualScreen.Width ||
            point.Y < virtualScreen.Y ||
            point.Y > virtualScreen.Y + virtualScreen.Height - 100 )
        {
          point.X = 100;
          point.Y = 100;
        }

        Location = point;

        // Search path.
        string searchPath = (string)key.GetValue( "searchPath", "" );

        if( searchPath != "" )
        {
          uiPath.Text = searchPath;
        }

        // Search filter.
        string searchFilter = (string)key.GetValue( "searchFilter", "" );

        if( searchFilter != "" )
        {
          uiFilter.Text = searchFilter;
        }

        // VS DevEnv.exe filename.
        VsDevEnvFilename = (string)key.GetValue( "vsDevEnvFilename", null );
      }
      catch( Exception ex )
      {
        MessageBox.Show(
          "Error loading settings:" + Environment.NewLine + Environment.NewLine +
            ex.Message,
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error );
      }
    }

    //-------------------------------------------------------------------------
    
    private void SaveSettings()
    {
      try
      {
        RegistryKey key = Registry.CurrentUser.OpenSubKey( "Software\\SolMate", true );

        if( key == null )
        {
          key = Registry.CurrentUser.CreateSubKey( "Software\\SolMate" );
        }

        // Window location.
        key.SetValue( "mainFormX", Location.X, RegistryValueKind.DWord );
        key.SetValue( "mainFormY", Location.Y, RegistryValueKind.DWord );

        // Search path.
        key.SetValue( "searchPath", uiPath.Text, RegistryValueKind.String );

        // Search filter.
        key.SetValue( "searchFilter", uiFilter.Text, RegistryValueKind.String );

        // VS DevEnv.exe filename.
        if( VsDevEnvFilename != null )
        {
          key.SetValue( "vsDevEnvFilename", VsDevEnvFilename, RegistryValueKind.String );
        }
      }
      catch( Exception ex )
      {
        MessageBox.Show(
          "Error saving settings:" + Environment.NewLine + Environment.NewLine +
            ex.Message,
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error );
      }
    }

    //-------------------------------------------------------------------------

    private static List<string> FindFiles(
      string searchPattern,
      string searchPath )
    {
      if( Directory.Exists( searchPath ) == false )
      {
        throw new DirectoryNotFoundException(
          "Directory '" + searchPath + "' was not found." );
      }

      string[] filenames =
        Directory.GetFiles(
          searchPath,
          searchPattern,
          SearchOption.AllDirectories );

      return new List<string>( filenames );
    }

    //-------------------------------------------------------------------------

    private void uiSearch_Click( object sender, EventArgs e )
    {
      try
      {
        // Busy cursor.
        Cursor.Current = Cursors.WaitCursor;

        // Clear the results list.
        uiSolutions.Items.Clear();

        // Do the search.
        List<string> filenames =
          FindFiles(
            '*' + uiFilter.Text + "*.sln",
            uiPath.Text );

        foreach( string fname in filenames )
        {
          uiSolutions.Items.Add( fname );
        }

        // Nothing found?
        if( uiSolutions.Items.Count == 0 )
        {
          MessageBox.Show(
            "No results.",
            "Search Results",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information );
        }

        // Back to normal cursor.
        Cursor.Current = Cursors.Default;
      }
      catch( Exception ex )
      {
        Cursor.Current = Cursors.Default;

        MessageBox.Show(
          "Whoops..." + Environment.NewLine + Environment.NewLine +
            ex.Message,
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error );
      }
    }

    //-------------------------------------------------------------------------
    
    private bool ValidateVsDevEnvFilename()
    {
      // Is it all good?
      if( VsDevEnvFilename != null &&
          File.Exists( VsDevEnvFilename ) )
      {
        return true;
      }

      // Is it at the default path?
      if( File.Exists( c_defaultVsDevEnvFilename ) )
      {
        return true;
      }

      // User will have to browse for it.
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.CheckFileExists = true;
      dlg.CheckPathExists = true;
      dlg.DefaultExt = "exe";
      dlg.FileName = "devenv.exe";
      dlg.InitialDirectory = @"c:\program files (x86)\";
      dlg.Multiselect = false;
      dlg.Title = "Find your devenv.exe file...";
      dlg.ShowDialog( this );

      if( dlg.FileName == null )
      {
        return false;
      }

      if( dlg.FileName.ToLower().Contains( "devenv.exe" ) == false )
      {
        MessageBox.Show(
          "This file doesn't appear to be the correct file.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error );

        return false;
      }

      VsDevEnvFilename = dlg.FileName;

      return true;
    }

    //-------------------------------------------------------------------------

    private void uiSolutions_SelectedIndexChanged( object sender, EventArgs e )
    {
      uiClean.Enabled = ( uiSolutions.SelectedItems.Count > 0 );
    }

    //-------------------------------------------------------------------------

    private void uiClean_Click( object sender, EventArgs e )
    {
      // We need VS.
      if( ValidateVsDevEnvFilename() == false )
      {
        return;
      }

      // Processing.
      try
      {
        Cursor.Current = Cursors.WaitCursor;

        // Clean each selected solution.
        foreach( string solutionFilename in uiSolutions.SelectedItems )
        {
          // Get the build profiles from the solution file.
          List<string> profiles = GetBuildProfilesFromSolutionFile( solutionFilename );

          // Let user decide which profiles to use.
          SelectionDlg dlg =
            new SelectionDlg(
              "Build Profiles",
              "Choose the profiles you'd like to clean:",
              profiles );

          dlg.ShowDialog( this );

          if( dlg.DialogResult == DialogResult.Cancel ||
              dlg.SelectedItems.Count == 0 )
          {
            return;
          }

          profiles = dlg.SelectedItems;

          // Go through and clean each selected profile.
          Enabled = false;

          foreach( string profileName in profiles )
          {
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.FileName = "process.bat";
            //info.EnvironmentVariables.Add( "ACTION", "CLEAN" );
            //info.EnvironmentVariables.Add( "VSDEVENV", VsDevEnvFilename );
            //info.EnvironmentVariables.Add( "SOLUTION", solutionFilename );
            //info.EnvironmentVariables.Add( "PROFILE", profileName );
            //info.UseShellExecute = false;

            //Process proc = new Process();
            //proc.StartInfo = info;
            //proc.Start();
            //proc.WaitForExit();

            Cursor.Current = Cursors.WaitCursor;

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = VsDevEnvFilename;
            info.Arguments =
              "\"" + solutionFilename + "\" " +
              "/CLEAN \"" + profileName + '"';

            Process proc = new Process();
            proc.StartInfo = info;
            proc.Start();
            proc.WaitForExit();            
          }
        }

        Enabled = true;
        Cursor.Current = Cursors.Default;
      }
      catch( Exception ex )
      {
        Enabled = true;

        MessageBox.Show(
          "Error while cleaning:" + Environment.NewLine + Environment.NewLine +
            ex.Message,
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error );
      }
    }

    //-------------------------------------------------------------------------

    private void uiBuild_Click( object sender, EventArgs e )
    {
      // We need VS.
      if( ValidateVsDevEnvFilename() == false )
      {
        return;
      }

      // Sure?
      if( MessageBox.Show(
            "Build the selected solution?",
            "Build?",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question ) == DialogResult.No )
      {
        return;
      }

      // Build each selected solution.
      try
      {
        Cursor.Current = Cursors.WaitCursor;

        foreach( string solutionFilename in uiSolutions.SelectedItems )
        {
          ProcessStartInfo info = new ProcessStartInfo();
          info.FileName = "process.bat";
          info.EnvironmentVariables.Add( "ACTION", "BUILD" );
          info.EnvironmentVariables.Add( "VSDEVENV", VsDevEnvFilename );
          info.EnvironmentVariables.Add( "SOLUTION", solutionFilename );
          info.UseShellExecute = false;

          Process.Start( info );
        }

        Cursor.Current = Cursors.Default;
      }
      catch( Exception ex )
      {
        MessageBox.Show(
          "Error while building:" + Environment.NewLine + Environment.NewLine +
            ex.Message,
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error );
      }
    }

    //-------------------------------------------------------------------------

    private static List<string> GetBuildProfilesFromSolutionFile( string filename )
    {
      List<string> profiles = new List<string>();

      string[] lines = File.ReadAllLines( filename );

      bool foundSection = false;

      foreach( string line in lines )
      {
        // Beginning of section?
        if( line.Contains( "GlobalSection(SolutionConfigurationPlatforms)" ) )
        {
          foundSection = true;
          continue;
        }

        // End of section?
        if( foundSection &&
            line.Contains( "EndGlobalSection" ) )
        {
          break;
        }

        // We're in the section, read the profiles.
        if( foundSection )
        {
          int index = line.IndexOf( '=' );

          if( index < 0 )
          {
            continue;
          }

          string profile = line.Substring( 0, index );
          profile = profile.Trim();
          profiles.Add( profile );
        }
      }

      return profiles;
    }

    //-------------------------------------------------------------------------
  }
}
