﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using Capa_Controlador.Controlador_Reclutamiento;


namespace Capa_Vista.Vista_Reclutamiento
{
    public partial class frmMostrarReclutas : Form
    {
        public frmMostrarReclutas()
        {
            InitializeComponent();
            funcMostrarTabla();
        }
        //estado de posible candidato

        int Estado = 0;
        int NoEntrevistado = 0;
        clsControladorReclutamiento Cont_R = new clsControladorReclutamiento();
        public void funcMostrarTabla()
        {

            
           


        }

      
        //función para cambiarle el nombre a las columnas del datagrid al momento de mostrar todos los datos
        public void funcNombresEncabezados()
        {
            dgvMostrarReclutas.Columns[0].HeaderText = "Código ID";
            dgvMostrarReclutas.Columns[1].HeaderText = "Primer Nombre";
            dgvMostrarReclutas.Columns[2].HeaderText = "Segundo Nombre";
            dgvMostrarReclutas.Columns[3].HeaderText = "Primer Apellido";
            dgvMostrarReclutas.Columns[4].HeaderText = "Segundo Apellido";
            dgvMostrarReclutas.Columns[5].HeaderText = "Puesto a Aplicar";
            dgvMostrarReclutas.Columns[6].HeaderText = "Departamento a Aplicar";
            dgvMostrarReclutas.Columns[7].HeaderText = "Email";
            dgvMostrarReclutas.Columns[8].HeaderText = "Telefono";
            dgvMostrarReclutas.Columns[9].HeaderText = "Tipo Licencia";
            dgvMostrarReclutas.Columns[10].HeaderText = "Profesión";
            dgvMostrarReclutas.Columns[11].HeaderText = "Nivel Formación Académica";

         
        }
        //función que bloquea todos los txt
        public void funcBloqueoTxt()
        {
            txtDepartamento.Enabled = false;
            txtIdRecluta.Enabled = false;
            txtPrimerNombre.Enabled = false;
            txtPrimerApellido.Enabled = false;
            txtPuesto.Enabled = false;
            txtDepartamento.Enabled = false;
            txtProfesion.Enabled = false;

        }

        //función que limpia todos los texbox
        public void funcLimpieza()
        {
            txtDepartamento.Text = "";
            txtIdRecluta.Text = "";
            txtPrimerNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtPuesto.Text = "";
            txtDepartamento.Text = "";
            txtProfesion.Text = "";
        }

        //funcion que limpia todos los radiobuttons(les quita la seleccion)
        public void funcLimpiezaRbtn()
        {
            rbtnFiltradoId.Checked = false;
            rbtnFiltradoNombre1.Checked = false;
            rbtnFiltradoApellido1.Checked = false;
            rbtnFiltradoPuesto.Checked = false;
            rbtnFiltradoDepto.Checked = false;
            rbtnFiltradoProfesion.Checked = false;

        }

        //se agrega una condicion if para limpiar todos los textbox con contenido, se bloquean todos excepto el correspondiente al radiobutton
        private void rbtnFiltradoId_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFiltradoId.Checked == true)
            {
                //se llama a la funcion funcLimpieza
                funcLimpieza();
                //se llama a la funcion funcBloqueoTxt
                funcBloqueoTxt();
                //se desbloquea el textbox correspondiente al radiobutton
                txtIdRecluta.Enabled = true;
            }
        }

        //se agrega una condicion if para limpiar todos los textbox con contenido, se bloquean todos excepto el correspondiente al radiobutton
        private void rbtnFiltradoNombre1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFiltradoNombre1.Checked == true)
            {
                //se llama a la funcion funcLimpieza
                funcLimpieza();
                //se llama a la funcion funcBloqueoTxt
                funcBloqueoTxt();
                //se desbloquea el textbox correspondiente al radiobutton
                txtPrimerNombre.Enabled = true;
            }
        }

        //se agrega una condicion if para limpiar todos los textbox con contenido, se bloquean todos excepto el correspondiente al radiobutton
        private void rbtnFiltradoApellido1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFiltradoApellido1.Checked == true)
            {
                //se llama a la funcion funcLimpieza
                funcLimpieza();
                //se llama a la funcion funcBloqueoTxt
                funcBloqueoTxt();
                //se desbloquea el textbox correspondiente al radiobutton
                txtPrimerApellido.Enabled = true;
            }
        }
        //se agrega una condicion if para limpiar todos los textbox con contenido, se bloquean todos excepto el correspondiente al radiobutton
        private void rbtnFiltradoPuesto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFiltradoPuesto.Checked == true)
            {
                //se llama a la funcion funcLimpieza
                funcLimpieza();
                //se llama a la funcion funcBloqueoTxt
                funcBloqueoTxt();
                //se desbloquea el textbox correspondiente al radiobutton
                txtPuesto.Enabled = true;
            }
        }

        //se agrega una condicion if para limpiar todos los textbox con contenido, se bloquean todos excepto el correspondiente al radiobutton
        private void rbtnFiltradoDepto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFiltradoDepto.Checked == true)
            {
                //se llama a la funcion funcLimpieza
                funcLimpieza();
                //se llama a la funcion funcBloqueoTxt
                funcBloqueoTxt();
                //se desbloquea el textbox correspondiente al radiobutton
                txtDepartamento.Enabled = true;
            }
        }

        //se agrega una condicion if para limpiar todos los textbox con contenido, se bloquean todos excepto el correspondiente al radiobutton
        private void rbtnFiltradoProfesion_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnFiltradoProfesion.Checked == true)
            {
                //se llama a la funcion funcLimpieza
                funcLimpieza();
                //se llama a la funcion funcBloqueoTxt
                funcBloqueoTxt();
                //se desbloquea el textbox correspondiente al radiobutton
                txtProfesion.Enabled = true;
            }

        }
        //Validacion para solo ingresar números en el txt Id
        private void funcNumero(object sender, KeyPressEventArgs e)
        {
            clsValidacion.funcNumeros(e);
        }
        //Validacion para solo ingresar letras
        private void funcLetra(object sender, KeyPressEventArgs e)
        {
            clsValidacion.funcLetras(e);
        }
        //Evento KeyUp para realizar el filtrado de los datos por id 
        private void txtIdEmpleado_KeyUp(object sender, KeyEventArgs e)
        {
            

        }
        //Evento KeyUp para realizar el filtrado de los datos por primer nombre
        private void txtPrimerNombre_KeyUp(object sender, KeyEventArgs e)
        {
           

        }
        //Evento KeyUp para realizar el filtrado de los datos por primer apellido
        private void txtPrimerApellido_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        //Evento KeyUp para realizar el filtrado de los datos por puesto
        private void txtPuesto_KeyUp(object sender, KeyEventArgs e)
        {
           
        }
        //Evento KeyUp para realizar el filtrado de los datos por departamento
        private void txtDepartamento_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        //Evento KeyUp para realizar el filtrado de los datos por profesion
        private void txtProfesion_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        //se coloca un máximo de dígitos para el textbox del id
        private void frmMostrarReclutas_Load(object sender, EventArgs e)
        {
            txtIdRecluta.MaxLength = 8;
        }
        //Se muestran nuevamente todos los datos de la entidad Empleado
        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            //Se llama a la funcion funcLimpiezaRbtn
            funcLimpiezaRbtn();
            //Se llama a la funcion funcLimpieza
            funcLimpieza();
            //Se llama a la funcion funcBloqueoTxt
            funcBloqueoTxt();
            //Se llama a la funcion funcMostrarTabla
            funcMostrarTabla();
        }

      
    }
}