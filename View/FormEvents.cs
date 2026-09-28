using ProyectoPresupuestoEvento.Model;
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
    public partial class FormEvents : Form
    {

        EventItemController eventController;

        public FormEvents(EventItemController controller)
        {
            eventController = controller;
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
