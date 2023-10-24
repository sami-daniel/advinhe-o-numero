using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Win32;

namespace AdvinheONumero
{
    public partial class Principal : Form
    {
        int digit = 1;
        public List<int[,]> matrizes = new List<int[,]>();
        Label labelSelect;
        TextBox txtChoice;
        int soma = 0;
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Pense em um numero. Em seguida digite sim para cada tabela \n em que ele aparece na tela, ou não caso nao apareca. Ao chega na ultima matriz, o número pensado aparecerá escrito", "Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            var clientSizeUsableAreaWidth = ClientSize.Width - (ClientSize.Width * 0.05);
            var clientSizeUsableAreaHeight = ClientSize.Height - (ClientSize.Width * 0.05);
            PanelCheckedListBox.Size = new Size((int)clientSizeUsableAreaWidth, (int)clientSizeUsableAreaHeight);
            PanelCheckedListBox.Location = new Point((ClientSize.Width - PanelCheckedListBox.Size.Width) / 2, (ClientSize.Height - PanelCheckedListBox.Size.Height) / 2);
            int listBoxWidth = PanelCheckedListBox.Size.Width / 3;
            int listBoxHeight = PanelCheckedListBox.Size.Height / 2;
            Height += (int)(Height * 0.25);

            // Cria a TextBox
            TextBox txtChoice = new TextBox();
            txtChoice.Size = new Size(150, 30);
            txtChoice.Location = new Point((ClientSize.Width - txtChoice.Width) / 2, Height - 100);
            this.txtChoice = txtChoice;
            Controls.Add(txtChoice);

            // Cria o botão
            Button button = new Button();
            button.Text = "Pronto";
            button.Size = new Size(150, 30);
            button.Location = new Point((ClientSize.Width - button.Width) / 2, Height - 70);
            button.Click += Button_Click;
            Controls.Add(button);

            // Cria a Label
            Label labelSelect = new Label();
            labelSelect.Text = "O número é presente na 1º matriz?:";
            labelSelect.Size = new Size(175, 30);
            labelSelect.Location = new Point(txtChoice.Left - labelSelect.Width -20, txtChoice.Top);
            Controls.Add(labelSelect);
            this.labelSelect = labelSelect;

            for (var i = 1; i <= 6; i++)
            {
                matrizes.Add(new int[8, 4]);
                var checkedListBox = new ListBox()
                {
                    Size = new Size(listBoxWidth, listBoxHeight),
                    MultiColumn = true,
                    ColumnWidth = Size.Height / 4,

                };

                if (i > 3)
                {
                    checkedListBox.Location = new Point((i - 4) * listBoxWidth, listBoxHeight);
                }
                else
                {
                    checkedListBox.Location = new Point((i - 1) * listBoxWidth, 0);
                }
                {
                    var realIndex = i - 1;
                    var initial = 0;
                    switch (i)
                    {
                        case 1:
                            initial = 32;
                            for (int x = 0; x < matrizes[realIndex].GetLength(0); x++)
                            {
                                for (int j = 0; j < matrizes[realIndex].GetLength(1); j++)
                                {
                                    matrizes[realIndex][x, j] = initial;
                                    initial++;
                                    checkedListBox.Items.Add(matrizes[realIndex][x, j]);
                                }
                            }
                            break;
                        case 2:
                            initial = 2;
                            for (int x = 0; x < matrizes[realIndex].GetLength(0); x++)
                            {
                                for (int j = 0; j < matrizes[realIndex].GetLength(1); j++)
                                {
                                    matrizes[realIndex][x, j] = initial;

                                    checkedListBox.Items.Add(matrizes[realIndex][x, j]);

                                    initial += initial % 2 != 0 ? 3 : 1;
                                }
                            }
                            break;
                        case 3:
                            initial = 8;
                            for (int x = 0; x < matrizes[realIndex].GetLength(0); x++)
                            {
                                for (int j = 0; j < matrizes[realIndex].GetLength(1); j++)
                                {
                                    matrizes[realIndex][x, j] = initial;

                                    switch (initial)
                                    {
                                        case 15:
                                        case 31:
                                        case 47:
                                            initial += 9;
                                            break;
                                        default:
                                            initial += 1;
                                            break;
                                    }
                                    checkedListBox.Items.Add(matrizes[realIndex][x, j]);
                                }
                            }
                            break;
                        case 4:
                            initial = 4;
                            for (int x = 0; x < matrizes[realIndex].GetLength(0); x++)
                            {
                                for (int j = 0; j < matrizes[realIndex].GetLength(1); j++)
                                {
                                    matrizes[realIndex][x, j] = initial;

                                    switch (initial)
                                    {
                                        case 7:
                                        case 15:
                                        case 23:
                                        case 31:
                                        case 39:
                                        case 47:
                                        case 55:
                                            initial += 5;
                                            break;
                                        default:
                                            initial += 1;
                                            break;
                                    }
                                    checkedListBox.Items.Add(matrizes[realIndex][x, j]);
                                }
                            }
                            break;
                        case 5:
                            initial = 1;
                            for (int x = 0; x < matrizes[realIndex].GetLength(0); x++)
                            {
                                for (int j = 0; j < matrizes[realIndex].GetLength(1); j++)
                                {
                                    matrizes[realIndex][x, j] = initial;
                                    initial += 2;
                                    checkedListBox.Items.Add(matrizes[realIndex][x, j]);
                                }
                            }
                            break;
                        case 6:
                            initial = 16;
                            for (int x = 0; x < matrizes[realIndex].GetLength(0); x++)
                            {
                                for (int j = 0; j < matrizes[realIndex].GetLength(1); j++)
                                {
                                    matrizes[realIndex][x, j] = initial;
                                    if (initial == 31)
                                        initial += 17;
                                    else initial++;
                                    checkedListBox.Items.Add(matrizes[realIndex][x, j]);
                                }
                            }
                            break;
                    }
                }
                PanelCheckedListBox.Controls.Add(checkedListBox);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {   
            bool verification;
            txtChoice.Focus();
            txtChoice.SelectAll();

            if (txtChoice.Text.ToLower() == "sim" || txtChoice.Text.ToLower() == "não" || txtChoice.Text.ToLower() == "nao")
            {
                if(txtChoice.Text.ToLower() == "sim")
                    verification = true;
                else
                    verification = false;

                if(digit < 7)
                {
                    if(verification)
                    {
                        soma += matrizes[digit - 1][0, 0];
                    }
                    digit++;
                   if(digit != 7)
                    {
                        labelSelect.Text = $"O número é presente na {digit}º matriz?";
                    }
                }
                if(digit == 7)
                {
                    MessageBox.Show($"O número pensado foi: {soma}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    digit = 1;
                    labelSelect.Text = $"O número é presente na {digit}º matriz?";
                    soma = 0;
                    txtChoice.Text = string.Empty;
                }

            }
            else
            {
                MessageBox.Show("Digite somente sim ou não!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox checkedListBox = sender as CheckedListBox;

            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        checkedListBox.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }
        }
    }
}
