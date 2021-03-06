﻿using System.Windows.Forms;

namespace CslaGenerator.Controls
{
    partial class GenerationReportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerationReportViewer));
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.generationReportCollectionDataGridView = new System.Windows.Forms.DataGridView();
            this.generationReportCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.objectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generationReportCollectionDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationReportCollectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = null;
            this.bindingNavigator.BindingSource = this.generationReportCollectionBindingSource;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(592, 25);
            this.bindingNavigator.TabIndex = 0;
            this.bindingNavigator.Text = "bindingNavigator";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // generationReportCollectionDataGridView
            // 
            this.generationReportCollectionDataGridView.AllowUserToAddRows = false;
            this.generationReportCollectionDataGridView.AllowUserToDeleteRows = false;
            this.generationReportCollectionDataGridView.AllowUserToResizeRows = false;
            this.generationReportCollectionDataGridView.AutoGenerateColumns = false;
            this.generationReportCollectionDataGridView.CausesValidation = false;
            this.generationReportCollectionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.generationReportCollectionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objectNameDataGridViewTextBoxColumn,
            this.objectTypeDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn});
            this.generationReportCollectionDataGridView.DataSource = this.generationReportCollectionBindingSource;
            this.generationReportCollectionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generationReportCollectionDataGridView.Location = new System.Drawing.Point(0, 25);
            this.generationReportCollectionDataGridView.Name = "generationReportCollectionDataGridView";
            this.generationReportCollectionDataGridView.ReadOnly = true;
            this.generationReportCollectionDataGridView.RowHeadersWidth = 16;
            this.generationReportCollectionDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.generationReportCollectionDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.generationReportCollectionDataGridView.ShowCellErrors = false;
            this.generationReportCollectionDataGridView.ShowEditingIcon = false;
            this.generationReportCollectionDataGridView.ShowRowErrors = false;
            this.generationReportCollectionDataGridView.Size = new System.Drawing.Size(592, 348);
            this.generationReportCollectionDataGridView.TabIndex = 1;
            // 
            // objectNameDataGridViewTextBoxColumn
            // 
            this.objectNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.objectNameDataGridViewTextBoxColumn.DataPropertyName = "ObjectName";
            this.objectNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.objectNameDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.objectNameDataGridViewTextBoxColumn.Name = "objectNameDataGridViewTextBoxColumn";
            this.objectNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.objectNameDataGridViewTextBoxColumn.Width = 60;
            // 
            // objectTypeDataGridViewTextBoxColumn
            // 
            this.objectTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.objectTypeDataGridViewTextBoxColumn.DataPropertyName = "ObjectType";
            this.objectTypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.objectTypeDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.objectTypeDataGridViewTextBoxColumn.Name = "objectTypeDataGridViewTextBoxColumn";
            this.objectTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.objectTypeDataGridViewTextBoxColumn.Width = 56;
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.HeaderText = "Message";
            this.messageDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            this.messageDataGridViewTextBoxColumn.ReadOnly = true;
            this.messageDataGridViewTextBoxColumn.Width = 75;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "File";
            this.fileNameDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // generationReportCollectionBindingSource
            // 
            this.generationReportCollectionBindingSource.DataSource = typeof(CslaGenerator.Metadata.GenerationReport);
            // 
            // GenerationReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(592, 373);
            this.Controls.Add(this.generationReportCollectionDataGridView);
            this.Controls.Add(this.bindingNavigator);
            this.Name = "GenerationReportViewer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
            this.DockAreas = (WeifenLuo.WinFormsUI.Docking.DockAreas)
                             WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom |
                             WeifenLuo.WinFormsUI.Docking.DockAreas.Float;
            this.TabText = "GenerationReportViewer";
            this.Text = "GenerationReportViewer";
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generationReportCollectionDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationReportCollectionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource generationReportCollectionBindingSource;
        private System.Windows.Forms.DataGridView generationReportCollectionDataGridView;
        private DataGridViewTextBoxColumn objectNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn objectTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
    }
}