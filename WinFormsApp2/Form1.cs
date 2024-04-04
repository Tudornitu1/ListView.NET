using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace WinFormsApp2
{
    [Serializable]
    public partial class Form1 : Form
    {
        Library library;
        public Form1()
        {
            library = new Library();
            InitializeComponent();
            ConfigureListView();
            UpdateListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var Form2 = new Form2())
            {
                if (Form2.ShowDialog() == DialogResult.OK)
                {
                    library.AddBook(Form2.NewBook);
                    UpdateListView();
                }
            }
        }

        private void ConfigureListView()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Title", 100);
            listView1.Columns.Add("Author", 100);
            listView1.Columns.Add("No of Pages", 100);
        }

        private void UpdateListView()
        {
            listView1.Items.Clear();
            library.books.Sort();
            foreach (var book in library.books)
            {
                ListViewItem item = new ListViewItem(new[] { book.Title, book.Author, book.NoOfPages.ToString() });
                listView1.Items.Add(item);
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Library));

            using (FileStream stream = File.Create("serialized.xml"))
            {
                serializer.Serialize(stream, library);
            }
        }

        public void DisplayLibrary()
        {
            listView1.Items.Clear();
            foreach (var book in library.books)
            {
                ListViewItem item = new ListViewItem(new[] { book.Title, book.Author, book.NoOfPages.ToString() });
                listView1.Items.Add(item);
            }
        }   

        public void toolStripButton2_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Library));
            using (FileStream stream = File.OpenRead("serialized.xml"))
            {
                library = (Library)serializer.Deserialize(stream);
                DisplayLibrary();
            }
        }
    }
}