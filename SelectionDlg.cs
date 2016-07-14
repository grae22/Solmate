using System.Windows.Forms;
using System.Collections.Generic;

namespace SolMate
{
  public partial class SelectionDlg : Form
  {
    //-------------------------------------------------------------------------

    public List<string> SelectedItems { get; private set; } = new List<string>();

    //-------------------------------------------------------------------------

    public SelectionDlg(
      string title,
      string instruction,
      List<string> options )
    {
      InitializeComponent();

      Text = title;
      uiOptionsBox.Text = instruction;

      foreach( string s in options )
      {
        uiOptions.Items.Add( s );
      }

      uiOk.Enabled = false;
    }

    //-------------------------------------------------------------------------

    private void uiOk_Click( object sender, System.EventArgs e )
    {
      for( int i = 0; i < uiOptions.CheckedItems.Count; i++ )
      {
        SelectedItems.Add( (string)uiOptions.CheckedItems[ i ] );
      }

      DialogResult = DialogResult.OK;
      Dispose();
    }

    //-------------------------------------------------------------------------

    private void uiOptions_SelectedIndexChanged( object sender, System.EventArgs e )
    {
      UpdateOkButtonState();
    }

    //-------------------------------------------------------------------------

    private void uiAll_Click( object sender, System.EventArgs e )
    {
      for( int i = 0; i < uiOptions.Items.Count; i++ )
      {
        uiOptions.SetItemChecked( i, true );
      }

      UpdateOkButtonState();
    }

    //-------------------------------------------------------------------------

    private void uiNone_Click( object sender, System.EventArgs e )
    {
      for( int i = 0; i < uiOptions.Items.Count; i++ )
      {
        uiOptions.SetItemChecked( i, false );
      }

      UpdateOkButtonState();
    }

    //-------------------------------------------------------------------------

    private void UpdateOkButtonState()
    {
      uiOk.Enabled = ( uiOptions.CheckedItems.Count > 0 );
    }

    //-------------------------------------------------------------------------
  }
}
