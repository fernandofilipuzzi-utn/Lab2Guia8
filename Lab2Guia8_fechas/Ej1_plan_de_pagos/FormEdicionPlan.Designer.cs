
namespace Ej1_plan_de_pagos
{
    partial class FormEdicionPlan
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
            this.gbDatosPago = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nupCuotas = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMonto = new System.Windows.Forms.TextBox();
            this.pickerInicio = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbApellidosYNombres = new System.Windows.Forms.TextBox();
            this.btnConsultarPlanes = new System.Windows.Forms.Button();
            this.btnCrearPlan = new System.Windows.Forms.Button();
            this.gbDatosPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupCuotas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosPago
            // 
            this.gbDatosPago.Controls.Add(this.label5);
            this.gbDatosPago.Controls.Add(this.nupCuotas);
            this.gbDatosPago.Controls.Add(this.label4);
            this.gbDatosPago.Controls.Add(this.label3);
            this.gbDatosPago.Controls.Add(this.tbMonto);
            this.gbDatosPago.Controls.Add(this.pickerInicio);
            this.gbDatosPago.Location = new System.Drawing.Point(16, 148);
            this.gbDatosPago.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDatosPago.Name = "gbDatosPago";
            this.gbDatosPago.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDatosPago.Size = new System.Drawing.Size(765, 162);
            this.gbDatosPago.TabIndex = 21;
            this.gbDatosPago.TabStop = false;
            this.gbDatosPago.Text = "Datos del pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "En Cuotas:";
            // 
            // nupCuotas
            // 
            this.nupCuotas.Location = new System.Drawing.Point(239, 71);
            this.nupCuotas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nupCuotas.Name = "nupCuotas";
            this.nupCuotas.Size = new System.Drawing.Size(101, 22);
            this.nupCuotas.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Fecha Inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Monto de la infracción";
            // 
            // tbMonto
            // 
            this.tbMonto.Location = new System.Drawing.Point(239, 27);
            this.tbMonto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMonto.Name = "tbMonto";
            this.tbMonto.Size = new System.Drawing.Size(304, 22);
            this.tbMonto.TabIndex = 18;
            // 
            // pickerInicio
            // 
            this.pickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pickerInicio.Location = new System.Drawing.Point(239, 113);
            this.pickerInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pickerInicio.Name = "pickerInicio";
            this.pickerInicio.Size = new System.Drawing.Size(184, 22);
            this.pickerInicio.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbDni);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbApellidosYNombres);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(765, 122);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Infractor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Apellidos y Nombres";
            // 
            // tbDni
            // 
            this.tbDni.Enabled = false;
            this.tbDni.Location = new System.Drawing.Point(245, 33);
            this.tbDni.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(297, 22);
            this.tbDni.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Dni";
            // 
            // tbApellidosYNombres
            // 
            this.tbApellidosYNombres.Enabled = false;
            this.tbApellidosYNombres.Location = new System.Drawing.Point(245, 84);
            this.tbApellidosYNombres.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbApellidosYNombres.Name = "tbApellidosYNombres";
            this.tbApellidosYNombres.Size = new System.Drawing.Size(297, 22);
            this.tbApellidosYNombres.TabIndex = 15;
            // 
            // btnConsultarPlanes
            // 
            this.btnConsultarPlanes.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConsultarPlanes.Location = new System.Drawing.Point(449, 314);
            this.btnConsultarPlanes.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnConsultarPlanes.Name = "btnConsultarPlanes";
            this.btnConsultarPlanes.Size = new System.Drawing.Size(264, 66);
            this.btnConsultarPlanes.TabIndex = 25;
            this.btnConsultarPlanes.Text = "Cancelar";
            this.btnConsultarPlanes.UseVisualStyleBackColor = true;
            // 
            // btnCrearPlan
            // 
            this.btnCrearPlan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCrearPlan.Location = new System.Drawing.Point(104, 317);
            this.btnCrearPlan.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCrearPlan.Name = "btnCrearPlan";
            this.btnCrearPlan.Size = new System.Drawing.Size(228, 63);
            this.btnCrearPlan.TabIndex = 9;
            this.btnCrearPlan.Text = "Confirmar datos";
            this.btnCrearPlan.UseVisualStyleBackColor = true;
            this.btnCrearPlan.Click += new System.EventHandler(this.btnCrearPlan_Click);
            // 
            // FormEdicionPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 395);
            this.Controls.Add(this.btnConsultarPlanes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDatosPago);
            this.Controls.Add(this.btnCrearPlan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEdicionPlan";
            this.Text = "Edición del plan de pagos";
            this.gbDatosPago.ResumeLayout(false);
            this.gbDatosPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupCuotas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConsultarPlanes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCrearPlan;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown nupCuotas;
        public System.Windows.Forms.TextBox tbMonto;
        public System.Windows.Forms.DateTimePicker pickerInicio;
        public System.Windows.Forms.TextBox tbDni;
        public System.Windows.Forms.TextBox tbApellidosYNombres;
    }
}