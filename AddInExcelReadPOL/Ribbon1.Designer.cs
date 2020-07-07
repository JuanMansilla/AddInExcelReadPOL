namespace AddInExcelReadPOL
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.BtnCargar = this.Factory.CreateRibbonButton();
            this.BtnGuardar = this.Factory.CreateRibbonButton();
            this.BtnConfigurar = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "Topografía";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.BtnCargar);
            this.group1.Items.Add(this.BtnGuardar);
            this.group1.Items.Add(this.BtnConfigurar);
            this.group1.Label = "Archivos Pol";
            this.group1.Name = "group1";
            // 
            // BtnCargar
            // 
            this.BtnCargar.Image = global::AddInExcelReadPOL.Properties.Resources._406_up;
            this.BtnCargar.Label = "Cargar";
            this.BtnCargar.Name = "BtnCargar";
            this.BtnCargar.ShowImage = true;
            this.BtnCargar.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnCargar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = global::AddInExcelReadPOL.Properties.Resources._200_add;
            this.BtnGuardar.Label = "Guardar";
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.ShowImage = true;
            this.BtnGuardar.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnGuardar_Click);
            // 
            // BtnConfigurar
            // 
            this.BtnConfigurar.Image = global::AddInExcelReadPOL.Properties.Resources._029_app;
            this.BtnConfigurar.Label = "Configuracion";
            this.BtnConfigurar.Name = "BtnConfigurar";
            this.BtnConfigurar.ShowImage = true;
            this.BtnConfigurar.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnConfigurar_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnCargar;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnGuardar;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnConfigurar;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
