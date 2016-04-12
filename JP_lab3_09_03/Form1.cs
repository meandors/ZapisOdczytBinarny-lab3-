  using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace JP_lab3_09_03
{
    public partial class Form1 : Form
    {
        private string _filePath;

        public Form1()
        {
            InitializeComponent();
            _filePath = "";
        }

        private void otwToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "c:\\";
            fileDialog.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;

            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (File.Exists(fileDialog.FileName))
                {
                    _filePath = fileDialog.FileName;
                    using (BinaryReader reader = new BinaryReader(File.Open(fileDialog.FileName, FileMode.Open)))
                    {
                        read(reader, kontrolka1);
                        read(reader, kontrolka2);
                        read(reader, kontrolka3);
                    }
                }
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_filePath == "")
            {
                MessageBox.Show("Brak ściezki do pliku, zapisz jako");
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Create(dialog.FileName)))
                    {
                        save(writer, kontrolka1);
                        save(writer, kontrolka2);
                        save(writer, kontrolka3);
                    }
                    _filePath = dialog.FileName;
                }
            
            }
            else
            {
                if (File.Exists(_filePath))
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(_filePath, FileMode.Create)))
                    {
                        save(writer, kontrolka1);
                        save(writer, kontrolka2);
                        save(writer, kontrolka3);
                    }
                }
            }
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _filePath = dialog.FileName;
                using (BinaryWriter writer = new BinaryWriter(File.Create(dialog.FileName)))
                {
                    save(writer, kontrolka1);
                    save(writer, kontrolka2);
                    save(writer, kontrolka3);
                }
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void read(BinaryReader reader, Kontrolka kontrolka)
        {
            int rb = reader.ReadInt32();
            kontrolka.checkedControl = rb;

            List<object> lista = new List<object>();
            int count = reader.ReadInt32();


            if (count == 0)
            {
                string temp = reader.ReadString();
                if (!temp.Equals("null"))
                {
                    lista.Add(temp);
                }
                kontrolka.listBoxCollection = lista;
            }
            else
            {
                if (rb == 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        lista.Add(reader.ReadInt32());
                    }
                    kontrolka.listBoxCollection = lista;
                }
                else if (rb == 1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        lista.Add(reader.ReadDouble());
                    }
                    kontrolka.listBoxCollection = lista;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        lista.Add(reader.ReadString());
                    }
                    kontrolka.listBoxCollection = lista;
                }
                
            }
        }

        private void save(BinaryWriter writer, Kontrolka kontrolka)
        {
            writer.Write(kontrolka.checkedControl);
            if (kontrolka.listBoxCollection == null)
            {
                writer.Write(0);
                writer.Write("null");
            }
            else
            {
                writer.Write(kontrolka.listBoxCount);
                if (kontrolka.checkedControl == 0)
                {
                    foreach (var item in kontrolka.listBoxCollection)
                    {
                        writer.Write(Int32.Parse(item.ToString()));
                    }
                }
                else if (kontrolka.checkedControl == 1)
                {
                    foreach (var item in kontrolka.listBoxCollection)
                    {
                        writer.Write(Double.Parse(item.ToString()));
                    }
                }
                else
                {
                    foreach (var item in kontrolka.listBoxCollection)
                    {
                        writer.Write(item.ToString());
                    }
                }

            }
        }
    }
}
