using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using PropertyGridSample;



namespace Idling_to_rule_the_gods_Save_Editor {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }
        //Controls.
        private TextBox txtBox = new TextBox();
        private Button btnAdd = new Button();
        private ListBox lstBox = new ListBox();
        private CheckBox chkBox = new CheckBox();
        private Label lblCount = new Label();

            public Dictionary<string, string> prefixToName = new Dictionary<string, string>();

        private void Form1_Load(object sender, EventArgs e) {
            Stuff();


            string result = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "prefixes.txt"));
            string[] text = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GameState.txt"));
            int x = 0;


            List<string> currentPrefixes = new List<string>();

            for (int i = 0; i < text.Length; i++) {

                // check if +1 i going right
                if (!(text[i].StartsWith(">") || text[i].StartsWith("<"))) {
                    // name file to check if it mathces

                    string prefix;
                    string name;
                    //find the prefix "a" or NS.n
                    if (text[i].Contains('"')) {

                        prefix = text[i].Substring(text[i].IndexOf('"') + 1);
                        prefix = prefix.Substring(0, prefix.IndexOf('"'));

                    }
                    else {
                        prefix = text[i].Substring(text[i].IndexOf("NS.n") + 4);
                        prefix = prefix.Substring(0, prefix.IndexOf('.'));

                        while (prefix.Length < 3) {
                            prefix = "0" + prefix;
                        }
                    }
                    prefix += ":";

                    string all = "";
                    foreach (var p in currentPrefixes) {
                        all += p;
                    }


                    name = text[i].Substring(text[i].IndexOf("this.") + 5);
                    name = name.Substring(0, name.IndexOfAny(new char[] { '.', ')', ',' }));



                    if (i + 1 < text.Length) {
                        if (text[i + 1].StartsWith(">")) {
                            for (int y = 0; y < text[i + 1].Length; y++) {
                                currentPrefixes.Add(prefix);
                            }
                        }
                        else if (text[i + 1].StartsWith("<")) {
                            for (int u = 0; u < text[i + 1].Length; u++) {
                                currentPrefixes.RemoveAt(currentPrefixes.Count - 1);
                            }
                        }
                    }
                    //Console.WriteLine(currentPrefixes);
                    prefix = all + prefix + "!";
                    prefixToName.Add(prefix, name);
                    //Console.WriteLine(prefix + name);
                    x++;
                }
                else {
                    //currentPrefix = "";
                }
            }


            Console.WriteLine(prefixToName["a:!"]);

            //Console.WriteLine(result);
        }


 
        private void Stuff() {

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            //this.Size = new System.Drawing.Size(155, 265);
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            //Format controls. Note: Controls inherit color from parent form.
            this.btnAdd.BackColor = Color.Gray;
            this.btnAdd.Text = "Add";
            this.btnAdd.Location = new System.Drawing.Point(90, 25);
            this.btnAdd.Size = new System.Drawing.Size(50, 25);

            this.txtBox.Text = "Text";
            this.txtBox.Location = new System.Drawing.Point(10, 25);
            this.txtBox.Size = new System.Drawing.Size(70, 20);

            this.lstBox.Items.Add("One");
            this.lstBox.Items.Add("Two");
            this.lstBox.Items.Add("Three");
            this.lstBox.Items.Add("Four");
            this.lstBox.Sorted = true;
            this.lstBox.Location = new System.Drawing.Point(10, 55);
            this.lstBox.Size = new System.Drawing.Size(130, 95);

            this.chkBox.Text = "Disable";
            this.chkBox.Location = new System.Drawing.Point(15, 190);
            this.chkBox.Size = new System.Drawing.Size(110, 30);

            this.lblCount.Text = lstBox.Items.Count.ToString() + " items";
            this.lblCount.Location = new System.Drawing.Point(55, 160);
            this.lblCount.Size = new System.Drawing.Size(65, 15);


            //Add controls to the form.
            this.Controls.Add(btnAdd);
            this.Controls.Add(txtBox);
            this.Controls.Add(lstBox);
            this.Controls.Add(chkBox);
            this.Controls.Add(lblCount);
        }

        private void decodeButton_Click(object sender, EventArgs e) {


            string text = DecompressString(inputTextBox.Text);
            string[] array = text.Split(new string[] { "-77-" }, StringSplitOptions.None);
            string[] parts = StringPartsFromBase64(array[0], "GameState");

            string[] premiumParts = StringPartsFromBase64(getStringFromParts(parts, "p"), "Premium");


            string[] cleanParts = new string[parts.Length];
            for (int i = 0; i < parts.Length; i++) {
                cleanParts[i] = parts[i].Substring(parts[i].IndexOf(":") + 1);
                //parts[i] = parts[i].Substring(0, parts[i].IndexOf(":") + 1);
            }






            int[] basicVariablesIndex = new int[] { 0, 1, 2, 3, 5, 10, 11, 12, 15, 16, 17, 18, 19, 25, 27, 28, 29, 30, 31, 32, 34, 40, 42, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 55, 56, 59 };
            string[] basicVariables = new string[basicVariablesIndex.Length];

            int[] collectionsIndex = new int[] { 4, 13, 14, 20, 33, 35, 36, 37, 38, 39, 43, 54, 57, 58 };
            string[] collections = new string[collectionsIndex.Length];

            int[] listsIndex = new int[] { 6, 7, 8, 9, 21, 22, 23, 24, 26, 41 };
            string[] lists = new string[listsIndex.Length];



            for (int i = 0; i < basicVariablesIndex.Length; i++) {
                basicVariables[i] = cleanParts[basicVariablesIndex[i]];
            }
            for (int i = 0; i < collectionsIndex.Length; i++) {
                collections[i] = cleanParts[collectionsIndex[i]];
            }
            for (int i = 0; i < listsIndex.Length; i++) {
                lists[i] = cleanParts[listsIndex[i]];
            }



            for (int i = 0; i < collections.Length; i++) {
                collections[i] = FromBase64(collections[i]);
            }








            //string[][] decoded = new string[parts.Length][];
            List<String> decoded = new List<string>();

            for (int i = 0; i < cleanParts.Length; i++) {
                string temp = cleanParts[i];

                try {
                    //temp = FromBase64(cleanParts[i]);

                }
                catch (Exception) {

                }
                decoded.Add(temp);
            }

            string[] sss = DecodeOld(cleanParts);
            List<Node> ssss = Decode(parts);

            String str = "";

            for (int i = 0; i < ssss.Count; i++) {

                str += i + "====" + ssss[i].value + "\n";
            }
            String str2 = "";


            for (int i = 0; i < ssss.Count; i++) {

                //str2 += ssss[i].prefix + "!\n";
            }

            inputTextBox.Text = str;

            getPrefix(ssss);

            foreach (var node in prefixes) {


                str2 += node + "!\n";

            }

            SetNames(ssss);



            FillTree(ssss);
            treeListView1.CellEditStarting += objlv_CellEditStarting;

            this.treeListView1.AutoResizeColumns();

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "names.txt"), str2);


            DataTable table = new DataTable();

            table.Columns.Add("Name");
            table.Columns.Add("Value");

            table.Rows.Add("god power", "552");
            for (int i = 0; i < premiumParts.Length; i++) {
                table.Rows.Add("Somethingg", premiumParts[i]);
            }

            dataGridView1.DataSource = table;



            ParameterGroup s = new ParameterGroup();

            propertyGrid1.SelectedObject = s;






        }
        public class Node {
            public string Name { get; set; }
            public string value { get; set; }
            public string prefix { get; set; }
            public List<Node> Children { get; set; }

            public Node(string name) {
                this.Name = name;
                this.Children = new List<Node>();
            }
        }

        void SetNames(Node node, string prefix = "") {
            //prefixes.Add(prefix + node.prefix);
            if (prefixToName.ContainsKey(prefix + node.prefix + "!")) {
                node.Name = prefixToName[prefix + node.prefix + "!"];
            }
            //Console.WriteLine(prefixToName[prefix + node.prefix + "!"]);
            if (node.Children.Count > 0) {
                foreach (var child in node.Children) {
                    SetNames(child, prefix + node.prefix);
                }
            }
            else {
            }
        }
        void SetNames(List<Node> nodes) {
            foreach (var node in nodes) {
                SetNames(node);
            }
        }

        public List<string> prefixes = new List<string>();
        void GetPrefix(Node node, string prefix = "") {

            prefixes.Add(prefix + node.prefix);
            if (node.Children.Count > 0) {
                if (node.Children[0].prefix == "list:") {
                    GetPrefix(node.Children[0], prefix + node.prefix);
                }
                else {
                    foreach (var child in node.Children) {
                        GetPrefix(child, prefix + node.prefix);
                    }
                }
            }
            else {
            }
        }
        void getPrefix(List<Node> nodes) {
            foreach (var node in nodes) {
                GetPrefix(node);
            }
        }
        IEnumerable<Node> Collect(List<Node> nodes) {
            foreach (Node node in nodes) {
                yield return node;

                foreach (var child in Collect(node.Children))
                    yield return child;
            }
        }

        private void FillTree(List<Node> data) {
            // set the delegate that the tree uses to know if a node is expandable
            this.treeListView1.CanExpandGetter = x => (x as Node).Children.Count > 0;
            // set the delegate that the tree uses to know the children of a node
            this.treeListView1.ChildrenGetter = x => (x as Node).Children;
            this.treeListView1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            // create the tree columns and set the delegates to print the desired object proerty
            var nameCol = new BrightIdeasSoftware.OLVColumn("Name", "Name");
            nameCol.AspectGetter = x => (x as Node).Name;
            nameCol.IsEditable = false;

            var value = new BrightIdeasSoftware.OLVColumn("Value", "Value");
            value.AspectGetter = x => (x as Node).value;
            value.AspectPutter = delegate(object x, object newValue) {

                (x as Node).value = (string)newValue;

            };


            //data.value = value;

            var prefix = new BrightIdeasSoftware.OLVColumn("prefix", "prefix");
            prefix.AspectGetter = x => (x as Node).prefix;
            prefix.IsEditable = false;

            //value.IsEditable = true;
            // add the columns to the tree
            this.treeListView1.Columns.Add(nameCol);
            this.treeListView1.Columns.Add(value);
            this.treeListView1.Columns.Add(prefix);
            // set the tree roots
            this.treeListView1.Roots = data;
        }



        public static List<Node> Decode(string[] s) {

            List<Node> final = new List<Node>();


            for (int i = 0; i < s.Length - 1; i++) {

                //create new node
                Node tempNode = new Node("test");
                tempNode.value = "-------";

                //remove and save prefix
                tempNode.prefix = s[i].Substring(0, s[i].IndexOf(":") + 1);
                s[i] = s[i].Substring(s[i].IndexOf(":") + 1);

                if (s[i].StartsWith("YT") || s[i].StartsWith("Yj")) {
                    if (s[i].Contains("&")) {
                        //list
                        string[] elements = s[i].Split('&');
                        List<Node> temp2 = new List<Node>();

                        for (int t = 0; t < elements.Length - 1; t++) {
                            if (!string.IsNullOrEmpty(elements[t])) {
                                Node n = new Node("coll");
                                n.value = " ";
                                n.Children = Decode(StringPartsFromBase64(elements[t]));
                                n.prefix = "list:"; // change later
                                temp2.Add(n);
                            }
                        }
                        tempNode.Children = temp2;
                        tempNode.Name = "list";
                        final.Add(tempNode);


                    }
                    else {
                        //collection
                        //base64 decode to string array
                        // decode(string array)

                        List<Node> temp = Decode(StringPartsFromBase64(s[i]));

                        tempNode.Name = "Coll";
                        tempNode.Children = temp;

                        final.Add(tempNode);

                    }
                }
                else {
                    tempNode.value = s[i];
                    final.Add(tempNode);

                }
            }
            return final;//toptal
        }



        public static string[] DecodeOld(string[] s) {

            List<string> final = new List<string>();

            for (int i = 0; i < s.Length; i++) {

                string combined = "";

                if (s[i].StartsWith("YT") || s[i].StartsWith("Yj")) {
                    if (s[i].Contains("&")) {
                        //list
                    }
                    else {
                        //collection
                        //base64 decode to string array
                        // decode(string array)

                        string[] temp = DecodeOld(StringPartsFromBase64(s[i]));

                        for (int j = 0; j < temp.Length; j++) {

                            combined += temp[j];
                        }

                        final.Add(combined);
                        //add string to list
                    }
                }
                else {
                    final.Add(s[i]);

                }
            }
            return final.ToArray();
        }



        public static string DecompressString(string compressedText) {
            return Encoding.UTF8.GetString(CLZF2.Decompress(Convert.FromBase64String(compressedText)));
        }

        public static string[] StringPartsFromBase64(string base64String, string logName = "") {
            string text = FromBase64(base64String);
            return text.Split(new char[]
            {
                ';'
            });
        }

        public static string ToBase64(string plainText, string logName = "") {
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(bytes);
        }

        public static string FromBase64(string base64EncodedData) {
            byte[] bytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string getStringFromParts(string[] parts, string partname) {
            for (int i = 0; i < parts.Length; i++) {
                string text = parts[i];
                if (text.StartsWith(partname)) {
                    string[] array = text.Split(new char[]
                    {
                        ':'
                    });
                    if (array.Length == 2) {
                        return array[1];
                    }
                }
            }
            return string.Empty;
        }

        private static string CombineStrings(string[] parts) {
            string combined = "";
            for (int i = 0; i < parts.Length; i++) {

                combined += parts[i];
                if (!(i == parts.Length - 1)) {
                    combined += ";";
                }
            }

            return combined;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
        
        private void objlv_CellEditStarting(object sender, CellEditEventArgs e) {
            //e.Column.AspectName gives the model column name of the editing column

            e.Control.Bounds = e.CellBounds;
        }
        /*
        private void objlv_CellEditFinishing(object sender, CellEditEventArgs e) {
            if (e.Column.AspectName == "Value") {
                //Here you can verify data, if the data is wrong, call
                if ((double)e.NewValue > 10000.0)
                    e.Cancel = true;
            }
        }
        */
        private void textBox1_TextChanged(object sender, EventArgs e) {

        }
    }
}
