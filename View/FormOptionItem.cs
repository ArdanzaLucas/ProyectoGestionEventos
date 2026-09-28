using ProyectoPresupuestoEvento.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPresupuestoEvento.View
{
    public partial class FormOptionItem : Form
    {
        OptionItemController optionItemController;
        public FormOptionItem(OptionItemController controller)
        {
            optionItemController = controller;
            InitializeComponent();
        }
    }
}
