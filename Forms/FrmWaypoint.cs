using PxgBot.Classes;
using System;
using System.Windows.Forms;

namespace PxgBot.Forms
{
    public partial class FrmWaypoint : Form
    {
        private string Node = "";
        private int ID = -1;
        private string WaypointName = "";
        private PXG.Position position;
        private ActionTypes actionTypes;
        private bool Edit;
        public FrmWaypoint(bool edit, string node = "")
        {
            Edit = edit;
            if (node != "")
            {
                Console.WriteLine("node: " + node);
                Node = node;
                if (node.Contains("'"))
                {
                    WaypointName = node.Split('\'')[1].Split('\'')[0];
                }
                string[] values = node.Replace("TreeNode:", "").Split(';');
                ID = int.Parse(values[0].Split(':')[0].Replace(" ", "").Replace(">", ""));
                string[] pos = values[0].Split('<')[1].Replace(">", "").Split(',');
                position = new PXG.Position(int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2]));
                actionTypes = (ActionTypes)Enum.Parse(typeof(ActionTypes), values[1]);
            }
            InitializeComponent();
        }

        private void FrmWaypoint_Load(object sender, EventArgs e)
        {
            var values = Enum.GetValues(typeof(ActionTypes));
            foreach (var value in values)
            {
                cmbActionTypes.Items.Add(value);
            }

            if (Edit)
            {
                txtName.Text = WaypointName;
                txtX.Text = position.X.ToString();
                txtY.Text = position.Y.ToString();
                txtZ.Text = position.Z.ToString();
                cmbActionTypes.SelectedIndex = (int)actionTypes;
            }
            else
            {
                txtX.Text = Character.X.ToString();
                txtY.Text = Character.Y.ToString();
                txtZ.Text = Character.Z.ToString();
                cmbActionTypes.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Edit)
            {
                CavebotAction cbAction = Cavebot.Script.FindLast(x => x.Position.X == position.X && x.Position.Y == position.Y && x.Position.Z == position.Z && x.Action == actionTypes);
                cbAction.Name = txtName.Text;
                cbAction.Position = new PXG.Position(int.Parse(txtX.Text), int.Parse(txtY.Text), int.Parse(txtZ.Text));
                cbAction.Action = (ActionTypes)Enum.Parse(typeof(ActionTypes), cmbActionTypes.SelectedItem.ToString());
            }
            else
            {
                int id = Cavebot.Script.Count;
                if (ID != -1)
                {
                    id = ID + 1;
                    foreach (CavebotAction action in Cavebot.Script)
                    {
                        if (action.ID >= id)
                        {
                            action.ID += 1;
                        }
                    }
                }
                Console.WriteLine("id added: " + id);
                CavebotAction cbAction = new CavebotAction(id, new PXG.Position(int.Parse(txtX.Text), int.Parse(txtY.Text), int.Parse(txtZ.Text)),
                                                        (ActionTypes)Enum.Parse(typeof(ActionTypes), cmbActionTypes.SelectedItem.ToString()), name: txtName.Text);
                Cavebot.Script.Add(cbAction);
            }
            this.Close();
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            txtX.Text = Character.X.ToString();
            txtY.Text = Character.Y.ToString();
            txtZ.Text = Character.Z.ToString();
        }

        private void btnNW_Click(object sender, EventArgs e)
        {
            txtX.Text = (int.Parse(txtX.Text) - 1).ToString();
            txtY.Text = (int.Parse(txtY.Text) - 1).ToString();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            txtX.Text = (int.Parse(txtX.Text) - 1).ToString();
        }

        private void btnNE_Click(object sender, EventArgs e)
        {
            txtX.Text = (int.Parse(txtX.Text) + 1).ToString();
            txtY.Text = (int.Parse(txtY.Text) - 1).ToString();
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            txtX.Text = (int.Parse(txtX.Text) - 1).ToString();
        }

        private void btnSW_Click(object sender, EventArgs e)
        {
            txtX.Text = (int.Parse(txtX.Text) - 1).ToString();
            txtY.Text = (int.Parse(txtY.Text) + 1).ToString();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            txtY.Text = (int.Parse(txtY.Text) + 1).ToString();
        }

        private void btnSE_Click(object sender, EventArgs e)
        {
            txtX.Text = (int.Parse(txtX.Text) + 1).ToString();
            txtY.Text = (int.Parse(txtY.Text) + 1).ToString();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            txtX.Text = (int.Parse(txtX.Text) + 1).ToString();
        }
    }
}
