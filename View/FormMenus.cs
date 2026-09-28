using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoPresupuestoEvento.Controller;

namespace ProyectoPresupuestoEvento.View
{
    public partial class FormMenus : Form
    {

        MenuController menuController;
        public FormMenus(MenuController controller)
        {
            menuController = controller;
            InitializeComponent();
        }
    }
}
