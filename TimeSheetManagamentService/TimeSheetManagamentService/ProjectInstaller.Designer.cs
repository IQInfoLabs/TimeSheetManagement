namespace TimeSheetManagamentService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TSM = new System.ServiceProcess.ServiceProcessInstaller();
            this.TimeSheetManagement = new System.ServiceProcess.ServiceInstaller();
            // 
            // TSM
            // 
            this.TSM.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.TSM.Password = null;
            this.TSM.Username = null;
            // 
            // TimeSheetManagement
            // 
            this.TimeSheetManagement.ServiceName = "TimeSheetManagement";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.TSM,
            this.TimeSheetManagement});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller TSM;
        private System.ServiceProcess.ServiceInstaller TimeSheetManagement;
    }
}