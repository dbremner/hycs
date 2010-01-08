using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

public class Form1 : Form
{
      private System.Windows.Forms.TreeView directoryTreeView;
     
      string substringDirectory;
       
      public Form1() {
        InitializeComponent();
        directoryTreeView.Nodes.Clear();
        
        String path = "c:\\windows";

        directoryTreeView.Nodes.Add( path );
        PopulateTreeView(path, directoryTreeView.Nodes[ 0 ] );
      }  

      public void PopulateTreeView(string directoryValue, TreeNode parentNode )
      {
          string[] directoryArray = 
           Directory.GetDirectories( directoryValue );

          try
          {
             if ( directoryArray.Length != 0 )
             {
                foreach ( string directory in directoryArray )
                {
                  substringDirectory = directory.Substring(
                  directory.LastIndexOf( '\\' ) + 1,
                  directory.Length - directory.LastIndexOf( '\\' ) - 1 );

                  TreeNode myNode = new TreeNode( substringDirectory );

                  parentNode.Nodes.Add( myNode );

                  PopulateTreeView( directory, myNode );
               }
             }
          } catch ( UnauthorizedAccessException ) {
            parentNode.Nodes.Add( "Access denied" );
          } // end catch
      }

      private void InitializeComponent()
      {
         this.directoryTreeView = new System.Windows.Forms.TreeView();
         this.SuspendLayout();
         // 
         // directoryTreeView
         // 
         this.directoryTreeView.Location = new System.Drawing.Point(12, 77);
         this.directoryTreeView.Name = "directoryTreeView";
         this.directoryTreeView.Size = new System.Drawing.Size(284, 265);
         this.directoryTreeView.TabIndex = 0;
         // 
         // TreeViewDirectoryStructureForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(304, 354);
         this.Controls.Add(this.directoryTreeView);
         this.Name = "TreeViewDirectoryStructureForm";
         this.Text = "TreeViewDirectoryStructure";
         this.ResumeLayout(false);
         this.PerformLayout();

      }
  [STAThread]
  static void Main()
  {
    Application.EnableVisualStyles();
    Application.Run(new Form1());
  }
}
