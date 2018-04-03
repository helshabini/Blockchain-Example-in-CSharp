using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace Blockchain_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string GetHash(string data)
        {
            var sha = new SHA256Managed();
            byte[] checksum = sha.ComputeHash(Encoding.UTF8.GetBytes(data));
            return BitConverter.ToString(checksum).Replace("-", String.Empty);
        }

        private void Consensus()
        {
            string A = txtt5gAHash3.Text;
            string B = txtt5gBHash3.Text;
            string C = txtt5gCHash3.Text;

            if (A == B)
            {
                grpA.BackColor = Color.LightGreen;
                grpB.BackColor = Color.LightGreen;

                if (B == C)
                {
                    grpC.BackColor = Color.LightGreen;
                }
                else
                {
                    grpC.BackColor = Color.LightPink;
                }
            }

            if (A == C)
            {
                grpA.BackColor = Color.LightGreen;
                grpC.BackColor = Color.LightGreen;

                if (B == C)
                {
                    grpB.BackColor = Color.LightGreen;
                }
                else
                {
                    grpB.BackColor = Color.LightPink;
                }
            }

            if (B == C)
            {
                grpB.BackColor = Color.LightGreen;
                grpC.BackColor = Color.LightGreen;

                if (A == C)
                {
                    grpA.BackColor = Color.LightGreen;
                }
                else
                {
                    grpA.BackColor = Color.LightPink;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtt1Hash.Text = GetHash(txtt1Data.Text);

            txtt2Hash.Text = GetHash(txtt2Nonce.Text + "|" + txtt2Data.Text);

            txtt3Hash.Text = GetHash(txtt3BlockId.Text + "|" + txtt3Nonce.Text + "|" + txtt3Data.Text);

            txtt4Hash1.Text = GetHash(txtt4BlockId1.Text + "|" + txtt4Nonce1.Text + "|" + txtt4Data1.Text + "|" + txtt4PrevHash1.Text);

            txtt5gAHash1.Text = GetHash(txtt5gABlockId1.Text + "|" + txtt5gANonce1.Text + "|" + txtt5gAData1.Text + "|" + txtt5gAPrevHash1.Text);

            txtt5gBHash1.Text = GetHash(txtt5gBBlockId1.Text + "|" + txtt5gBNonce1.Text + "|" + txtt5gBData1.Text + "|" + txtt5gBPrevHash1.Text);

            txtt5gCHash1.Text = GetHash(txtt5gCBlockId1.Text + "|" + txtt5gCNonce1.Text + "|" + txtt5gCData1.Text + "|" + txtt5gCPrevHash1.Text);
        }

        private void txtt1Data_TextChanged(object sender, EventArgs e)
        {
            txtt1Hash.Text = GetHash(txtt1Data.Text);
        }

        private void txtt2Data_TextChanged(object sender, EventArgs e)
        {
            txtt2Hash.Text = GetHash(txtt2Nonce.Text + "|" + txtt2Data.Text);
        }

        private void txtt2Hash_TextChanged(object sender, EventArgs e)
        {
            if (txtt2Hash.Text.StartsWith("000"))
            {
                txtt2Hash.BackColor = Color.LightGreen;
            }
            else
            {
                txtt2Hash.BackColor = Color.Pink;
            }
        }

        private void btnt2Mine_Click(object sender, EventArgs e)
        {
            txtt2Nonce.Text = "0";

            while (!GetHash(txtt2Nonce.Text + "|" + txtt2Data.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt2Nonce.Text) + 1;

                txtt2Nonce.Text = Nonce.ToString();
                txtt2Hash.Text = GetHash(txtt2Nonce.Text + "|" + txtt2Data.Text);

                if (Nonce % 13 == 0)
                {
                    txtt2Nonce.Refresh();
                    txtt2Hash.Refresh();
                }
            }
        }

        private void txtt3Data_TextChanged(object sender, EventArgs e)
        {
            txtt3Hash.Text = GetHash(txtt3BlockId.Text + "|" + txtt3Nonce.Text + "|" + txtt3Data.Text);
        }

        private void txtt3Hash_TextChanged(object sender, EventArgs e)
        {
            if (txtt3Hash.Text.StartsWith("000"))
            {
                txtt3Hash.BackColor = Color.LightGreen;
            }
            else
            {
                txtt3Hash.BackColor = Color.Pink;
            }
        }

        private void btnt3Mine_Click(object sender, EventArgs e)
        {
            txtt3Nonce.Text = "0";

            while (!GetHash(txtt3BlockId.Text + "|" + txtt3Nonce.Text + "|" + txtt3Data.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt3Nonce.Text) + 1;

                txtt3Nonce.Text = Nonce.ToString();
                txtt3Hash.Text = GetHash(txtt3BlockId.Text + "|" + txtt3Nonce.Text + "|" + txtt3Data.Text);

                if (Nonce % 13 == 0)
                {
                    txtt3Nonce.Refresh();
                    txtt3Hash.Refresh();
                }
            }
        }

        private void txtt4Data1_TextChanged(object sender, EventArgs e)
        {
            txtt4Hash1.Text = GetHash(txtt4BlockId1.Text + "|" + txtt4Nonce1.Text + "|" + txtt4Data1.Text + "|" + txtt4PrevHash1.Text);
        }

        private void txtt4PrevHash1_TextChanged(object sender, EventArgs e)
        {
            if (txtt4PrevHash1.Text.StartsWith("000"))
            {
                txtt4PrevHash1.BackColor = Color.LightGreen;
            }
            else
            {
                txtt4PrevHash1.BackColor = Color.Pink;
            }

            txtt4Hash1.Text = GetHash(txtt4BlockId1.Text + "|" + txtt4Nonce1.Text + "|" + txtt4Data1.Text + "|" + txtt4PrevHash1.Text);
        }

        private void txtt4Hash1_TextChanged(object sender, EventArgs e)
        {
            if (txtt4Hash1.Text.StartsWith("000"))
            {
                txtt4Hash1.BackColor = Color.LightGreen;
            }
            else
            {
                txtt4Hash1.BackColor = Color.Pink;
            }

            txtt4PrevHash2.Text = txtt4Hash1.Text;
        }

        private void btnt4Mine1_Click(object sender, EventArgs e)
        {
            txtt4Nonce1.Text = "0";

            while (!GetHash(txtt4BlockId1.Text + "|" + txtt4Nonce1.Text + "|" + txtt4Data1.Text + "|" + txtt4PrevHash1.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt4Nonce1.Text) + 1;

                txtt4Nonce1.Text = Nonce.ToString();
                txtt4Hash1.Text = GetHash(txtt4BlockId1.Text + "|" + txtt4Nonce1.Text + "|" + txtt4Data1.Text + "|" + txtt4PrevHash1.Text);

                if (Nonce % 13 == 0)
                {
                    txtt4Nonce1.Refresh();
                    txtt4Hash1.Refresh();
                }
            }
        }

        private void txtt4Data2_TextChanged(object sender, EventArgs e)
        {
            txtt4Hash2.Text = GetHash(txtt4BlockId2.Text + "|" + txtt4Nonce2.Text + "|" + txtt4Data2.Text + "|" + txtt4PrevHash2.Text);
        }

        private void txtt4PrevHash2_TextChanged(object sender, EventArgs e)
        {
            if (txtt4PrevHash2.Text.StartsWith("000"))
            {
                txtt4PrevHash2.BackColor = Color.LightGreen;
            }
            else
            {
                txtt4PrevHash2.BackColor = Color.Pink;
            }

            txtt4Hash2.Text = GetHash(txtt4BlockId2.Text + "|" + txtt4Nonce2.Text + "|" + txtt4Data2.Text + "|" + txtt4PrevHash2.Text);
        }

        private void txtt4Hash2_TextChanged(object sender, EventArgs e)
        {
            if (txtt4Hash2.Text.StartsWith("000"))
            {
                txtt4Hash2.BackColor = Color.LightGreen;
            }
            else
            {
                txtt4Hash2.BackColor = Color.Pink;
            }

            txtt4PrevHash3.Text = txtt4Hash2.Text;
        }

        private void btnt4Mine2_Click(object sender, EventArgs e)
        {
            txtt4Nonce2.Text = "0";

            while (!GetHash(txtt4BlockId2.Text + "|" + txtt4Nonce2.Text + "|" + txtt4Data2.Text + "|" + txtt4PrevHash2.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt4Nonce2.Text) + 1;

                txtt4Nonce2.Text = Nonce.ToString();
                txtt4Hash2.Text = GetHash(txtt4BlockId2.Text + "|" + txtt4Nonce2.Text + "|" + txtt4Data2.Text + "|" + txtt4PrevHash2.Text);

                if (Nonce % 13 == 0)
                {
                    txtt4Nonce2.Refresh();
                    txtt4Hash2.Refresh();
                }
            }
        }

        private void txtt4Data3_TextChanged(object sender, EventArgs e)
        {
            txtt4Hash3.Text = GetHash(txtt4BlockId3.Text + "|" + txtt4Nonce3.Text + "|" + txtt4Data3.Text + "|" + txtt4PrevHash3.Text);
        }

        private void txtt4PrevHash3_TextChanged(object sender, EventArgs e)
        {
            if (txtt4PrevHash3.Text.StartsWith("000"))
            {
                txtt4PrevHash3.BackColor = Color.LightGreen;
            }
            else
            {
                txtt4PrevHash3.BackColor = Color.Pink;
            }

            txtt4Hash3.Text = GetHash(txtt4BlockId3.Text + "|" + txtt4Nonce3.Text + "|" + txtt4Data3.Text + "|" + txtt4PrevHash3.Text);
        }

        private void txtt4Hash3_TextChanged(object sender, EventArgs e)
        {
            if (txtt4Hash3.Text.StartsWith("000"))
            {
                txtt4Hash3.BackColor = Color.LightGreen;
            }
            else
            {
                txtt4Hash3.BackColor = Color.Pink;
            }
        }

        private void btnt4Mine3_Click(object sender, EventArgs e)
        {
            txtt4Nonce3.Text = "0";

            while (!GetHash(txtt4BlockId3.Text + "|" + txtt4Nonce3.Text + "|" + txtt4Data3.Text + "|" + txtt4PrevHash3.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt4Nonce3.Text) + 1;

                txtt4Nonce3.Text = Nonce.ToString();
                txtt4Hash3.Text = GetHash(txtt4BlockId3.Text + "|" + txtt4Nonce3.Text + "|" + txtt4Data3.Text + "|" + txtt4PrevHash3.Text);

                if (Nonce % 13 == 0)
                {
                    txtt4Nonce3.Refresh();
                    txtt4Hash3.Refresh();
                }
            }
        }

        private void txtt5gAData1_TextChanged(object sender, EventArgs e)
        {
            txtt5gAHash1.Text = GetHash(txtt5gABlockId1.Text + "|" + txtt5gANonce1.Text + "|" + txtt5gAData1.Text + "|" + txtt5gAPrevHash1.Text);
        }

        private void txtt5gAHash1_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gAHash1.Text.StartsWith("000"))
            {
                txtt5gAHash1.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gAHash1.BackColor = Color.Pink;
            }

            txtt5gAPrevHash2.Text = txtt5gAHash1.Text;
        }

        private void btnt5gAMine1_Click(object sender, EventArgs e)
        {
            txtt5gANonce1.Text = "0";

            while (!GetHash(txtt5gABlockId1.Text + "|" + txtt5gANonce1.Text + "|" + txtt5gAData1.Text + "|" + txtt5gAPrevHash1.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt5gANonce1.Text) + 1;

                txtt5gANonce1.Text = Nonce.ToString();
                txtt5gAHash1.Text = GetHash(txtt5gABlockId1.Text + "|" + txtt5gANonce1.Text + "|" + txtt5gAData1.Text + "|" + txtt5gAPrevHash1.Text);

                if (Nonce % 13 == 0)
                {
                    txtt5gANonce1.Refresh();
                    txtt5gAHash1.Refresh();
                }
            }
        }

        private void txtt5gAData2_TextChanged(object sender, EventArgs e)
        {
            txtt5gAHash2.Text = GetHash(txtt5gABlockId2.Text + "|" + txtt5gANonce2.Text + "|" + txtt5gAData2.Text + "|" + txtt5gAPrevHash2.Text);
        }

        private void txtt5gAPrevHash2_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gAPrevHash2.Text.StartsWith("000"))
            {
                txtt5gAPrevHash2.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gAPrevHash2.BackColor = Color.Pink;
            }

            txtt5gAHash2.Text = GetHash(txtt5gABlockId2.Text + "|" + txtt5gANonce2.Text + "|" + txtt5gAData2.Text + "|" + txtt5gAPrevHash2.Text);
        }

        private void txtt5gAHash2_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gAHash2.Text.StartsWith("000"))
            {
                txtt5gAHash2.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gAHash2.BackColor = Color.Pink;
            }

            txtt5gAPrevHash3.Text = txtt5gAHash2.Text;
        }

        private void btnt5gAMine2_Click(object sender, EventArgs e)
        {
            txtt5gANonce2.Text = "0";

            while (!GetHash(txtt5gABlockId2.Text + "|" + txtt5gANonce2.Text + "|" + txtt5gAData2.Text + "|" + txtt5gAPrevHash2.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt5gANonce2.Text) + 1;

                txtt5gANonce2.Text = Nonce.ToString();
                txtt5gAHash2.Text = GetHash(txtt5gABlockId2.Text + "|" + txtt5gANonce2.Text + "|" + txtt5gAData2.Text + "|" + txtt5gAPrevHash2.Text);

                if (Nonce % 13 == 0)
                {
                    txtt5gANonce2.Refresh();
                    txtt5gAHash2.Refresh();
                }
            }
        }

        private void txtt5gAData3_TextChanged(object sender, EventArgs e)
        {
            txtt5gAHash3.Text = GetHash(txtt5gABlockId3.Text + "|" + txtt5gANonce3.Text + "|" + txtt5gAData3.Text + "|" + txtt5gAPrevHash3.Text);
        }

        private void txtt5gAPrevHash3_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gAPrevHash3.Text.StartsWith("000"))
            {
                txtt5gAPrevHash3.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gAPrevHash3.BackColor = Color.Pink;
            }

            txtt5gAHash3.Text = GetHash(txtt5gABlockId3.Text + "|" + txtt5gANonce3.Text + "|" + txtt5gAData3.Text + "|" + txtt5gAPrevHash3.Text);
        }

        private void txtt5gAHash3_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gAHash3.Text.StartsWith("000"))
            {
                txtt5gAHash3.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gAHash3.BackColor = Color.Pink;
            }

            Consensus();
        }

        private void btnt5gAMine3_Click(object sender, EventArgs e)
        {
            txtt5gANonce3.Text = "0";

            while (!GetHash(txtt5gABlockId3.Text + "|" + txtt5gANonce3.Text + "|" + txtt5gAData3.Text + "|" + txtt5gAPrevHash3.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt5gANonce3.Text) + 1;

                txtt5gANonce3.Text = Nonce.ToString();
                txtt5gAHash3.Text = GetHash(txtt5gABlockId3.Text + "|" + txtt5gANonce3.Text + "|" + txtt5gAData3.Text + "|" + txtt5gAPrevHash3.Text);

                if (Nonce % 13 == 0)
                {
                    txtt5gANonce3.Refresh();
                    txtt5gAHash3.Refresh();
                }
            }
        }

        private void txtt5gBData1_TextChanged(object sender, EventArgs e)
        {
            txtt5gBHash1.Text = GetHash(txtt5gBBlockId1.Text + "|" + txtt5gBNonce1.Text + "|" + txtt5gBData1.Text + "|" + txtt5gBPrevHash1.Text);
        }

        private void txtt5gBHash1_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gBHash1.Text.StartsWith("000"))
            {
                txtt5gBHash1.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gBHash1.BackColor = Color.Pink;
            }

            txtt5gBPrevHash2.Text = txtt5gBHash1.Text;
        }

        private void btnt5gBMine1_Click(object sender, EventArgs e)
        {
            txtt5gBNonce1.Text = "0";

            while (!GetHash(txtt5gBBlockId1.Text + "|" + txtt5gBNonce1.Text + "|" + txtt5gBData1.Text + "|" + txtt5gBPrevHash1.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt5gBNonce1.Text) + 1;

                txtt5gBNonce1.Text = Nonce.ToString();
                txtt5gBHash1.Text = GetHash(txtt5gBBlockId1.Text + "|" + txtt5gBNonce1.Text + "|" + txtt5gBData1.Text + "|" + txtt5gBPrevHash1.Text);

                if (Nonce % 13 == 0)
                {
                    txtt5gBNonce1.Refresh();
                    txtt5gBHash1.Refresh();
                }
            }
        }

        private void txtt5gBData2_TextChanged(object sender, EventArgs e)
        {
            txtt5gBHash2.Text = GetHash(txtt5gBBlockId2.Text + "|" + txtt5gBNonce2.Text + "|" + txtt5gBData2.Text + "|" + txtt5gBPrevHash2.Text);
        }

        private void txtt5gBPrevHash2_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gBPrevHash2.Text.StartsWith("000"))
            {
                txtt5gBPrevHash2.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gBPrevHash2.BackColor = Color.Pink;
            }

            txtt5gBHash2.Text = GetHash(txtt5gBBlockId2.Text + "|" + txtt5gBNonce2.Text + "|" + txtt5gBData2.Text + "|" + txtt5gBPrevHash2.Text);
        }

        private void txtt5gBHash2_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gBHash2.Text.StartsWith("000"))
            {
                txtt5gBHash2.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gBHash2.BackColor = Color.Pink;
            }

            txtt5gBPrevHash3.Text = txtt5gBHash2.Text;
        }

        private void btnt5gBMine2_Click(object sender, EventArgs e)
        {
            txtt5gBNonce2.Text = "0";

            while (!GetHash(txtt5gBBlockId2.Text + "|" + txtt5gBNonce2.Text + "|" + txtt5gBData2.Text + "|" + txtt5gBPrevHash2.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt5gBNonce2.Text) + 1;

                txtt5gBNonce2.Text = Nonce.ToString();
                txtt5gBHash2.Text = GetHash(txtt5gBBlockId2.Text + "|" + txtt5gBNonce2.Text + "|" + txtt5gBData2.Text + "|" + txtt5gBPrevHash2.Text);

                if (Nonce % 13 == 0)
                {
                    txtt5gBNonce2.Refresh();
                    txtt5gBHash2.Refresh();
                }
            }
        }

        private void txtt5gBData3_TextChanged(object sender, EventArgs e)
        {
            txtt5gBHash3.Text = GetHash(txtt5gBBlockId3.Text + "|" + txtt5gBNonce3.Text + "|" + txtt5gBData3.Text + "|" + txtt5gBPrevHash3.Text);
        }

        private void txtt5gBPrevHash3_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gBPrevHash3.Text.StartsWith("000"))
            {
                txtt5gBPrevHash3.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gBPrevHash3.BackColor = Color.Pink;
            }

            txtt5gBHash3.Text = GetHash(txtt5gBBlockId3.Text + "|" + txtt5gBNonce3.Text + "|" + txtt5gBData3.Text + "|" + txtt5gBPrevHash3.Text);
        }

        private void txtt5gBHash3_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gBHash3.Text.StartsWith("000"))
            {
                txtt5gBHash3.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gBHash3.BackColor = Color.Pink;
            }

            Consensus();
        }

        private void btnt5gBMine3_Click(object sender, EventArgs e)
        {
            txtt5gBNonce3.Text = "0";

            while (!GetHash(txtt5gBBlockId3.Text + "|" + txtt5gBNonce3.Text + "|" + txtt5gBData3.Text + "|" + txtt5gBPrevHash3.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt5gBNonce3.Text) + 1;

                txtt5gBNonce3.Text = Nonce.ToString();
                txtt5gBHash3.Text = GetHash(txtt5gBBlockId3.Text + "|" + txtt5gBNonce3.Text + "|" + txtt5gBData3.Text + "|" + txtt5gBPrevHash3.Text);

                if (Nonce % 13 == 0)
                {
                    txtt5gBNonce3.Refresh();
                    txtt5gBHash3.Refresh();
                }
            }
        }

        private void txtt5gCData1_TextChanged(object sender, EventArgs e)
        {
            txtt5gCHash1.Text = GetHash(txtt5gCBlockId1.Text + "|" + txtt5gCNonce1.Text + "|" + txtt5gCData1.Text + "|" + txtt5gCPrevHash1.Text);
        }

        private void txtt5gCHash1_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gCHash1.Text.StartsWith("000"))
            {
                txtt5gCHash1.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gCHash1.BackColor = Color.Pink;
            }

            txtt5gCPrevHash2.Text = txtt5gCHash1.Text;
        }

        private void btnt5gCMine1_Click(object sender, EventArgs e)
        {
            txtt5gCNonce1.Text = "0";

            while (!GetHash(txtt5gCBlockId1.Text + "|" + txtt5gCNonce1.Text + "|" + txtt5gCData1.Text + "|" + txtt5gCPrevHash1.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt5gCNonce1.Text) + 1;

                txtt5gCNonce1.Text = Nonce.ToString();
                txtt5gCHash1.Text = GetHash(txtt5gCBlockId1.Text + "|" + txtt5gCNonce1.Text + "|" + txtt5gCData1.Text + "|" + txtt5gCPrevHash1.Text);

                if (Nonce % 13 == 0)
                {
                    txtt5gCNonce1.Refresh();
                    txtt5gCHash1.Refresh();
                }
            }
        }

        private void txtt5gCData2_TextChanged(object sender, EventArgs e)
        {
            txtt5gCHash2.Text = GetHash(txtt5gCBlockId2.Text + "|" + txtt5gCNonce2.Text + "|" + txtt5gCData2.Text + "|" + txtt5gCPrevHash2.Text);
        }

        private void txtt5gCPrevHash2_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gCPrevHash2.Text.StartsWith("000"))
            {
                txtt5gCPrevHash2.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gCPrevHash2.BackColor = Color.Pink;
            }

            txtt5gCHash2.Text = GetHash(txtt5gCBlockId2.Text + "|" + txtt5gCNonce2.Text + "|" + txtt5gCData2.Text + "|" + txtt5gCPrevHash2.Text);
        }

        private void txtt5gCHash2_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gCHash2.Text.StartsWith("000"))
            {
                txtt5gCHash2.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gCHash2.BackColor = Color.Pink;
            }

            txtt5gCPrevHash3.Text = txtt5gCHash2.Text;
        }

        private void btnt5gCMine2_Click(object sender, EventArgs e)
        {
            txtt5gCNonce2.Text = "0";

            while (!GetHash(txtt5gCBlockId2.Text + "|" + txtt5gCNonce2.Text + "|" + txtt5gCData2.Text + "|" + txtt5gCPrevHash2.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt5gCNonce2.Text) + 1;

                txtt5gCNonce2.Text = Nonce.ToString();
                txtt5gCHash2.Text = GetHash(txtt5gCBlockId2.Text + "|" + txtt5gCNonce2.Text + "|" + txtt5gCData2.Text + "|" + txtt5gCPrevHash2.Text);

                if (Nonce % 13 == 0)
                {
                    txtt5gCNonce2.Refresh();
                    txtt5gCHash2.Refresh();
                }
            }
        }

        private void txtt5gCData3_TextChanged(object sender, EventArgs e)
        {
            txtt5gCHash3.Text = GetHash(txtt5gCBlockId3.Text + "|" + txtt5gCNonce3.Text + "|" + txtt5gCData3.Text + "|" + txtt5gCPrevHash3.Text);
        }

        private void txtt5gCPrevHash3_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gCPrevHash3.Text.StartsWith("000"))
            {
                txtt5gCPrevHash3.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gCPrevHash3.BackColor = Color.Pink;
            }

            txtt5gCHash3.Text = GetHash(txtt5gCBlockId3.Text + "|" + txtt5gCNonce3.Text + "|" + txtt5gCData3.Text + "|" + txtt5gCPrevHash3.Text);
        }

        private void txtt5gCHash3_TextChanged(object sender, EventArgs e)
        {
            if (txtt5gCHash3.Text.StartsWith("000"))
            {
                txtt5gCHash3.BackColor = Color.LightGreen;
            }
            else
            {
                txtt5gCHash3.BackColor = Color.Pink;
            }

            Consensus();
        }

        private void btnt5gCMine3_Click(object sender, EventArgs e)
        {
            txtt5gCNonce3.Text = "0";

            while (!GetHash(txtt5gCBlockId3.Text + "|" + txtt5gCNonce3.Text + "|" + txtt5gCData3.Text + "|" + txtt5gCPrevHash3.Text).StartsWith("000"))
            {
                int Nonce = int.Parse(txtt5gCNonce3.Text) + 1;

                txtt5gCNonce3.Text = Nonce.ToString();
                txtt5gCHash3.Text = GetHash(txtt5gCBlockId3.Text + "|" + txtt5gCNonce3.Text + "|" + txtt5gCData3.Text + "|" + txtt5gCPrevHash3.Text);

                if (Nonce % 13 == 0)
                {
                    txtt5gCNonce3.Refresh();
                    txtt5gCHash3.Refresh();
                }
            }
        }
    }
}
