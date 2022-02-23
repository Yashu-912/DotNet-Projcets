public class Document
    {
        public string Title { get; private set; }
        public string Content { get; private set; }

        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }

public class DocumentManager
    {
        private readonly Queue<Document> documentQueue = new Queue<Document>();

        public void AddDocument(Document doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }

        public Document GetDocument()
        {
            Document doc = null;
            lock (this)
            {
                doc = documentQueue.Dequeue();
            }
            return doc;
        }

        public bool IsDocumentAvailable
        {
            get
            {
                return documentQueue.Count > 0;
            }
        }
    }


public class ProcessDocuments
    {
        public static void Start(DocumentManager dm)
        {
            new Thread(new ProcessDocuments(dm).Run).Start();
        }

        protected ProcessDocuments(DocumentManager dm)
        {
            documentManager = dm;
        }

        private DocumentManager documentManager;

        protected void Run()
        {
            while (true)
            {
                if (documentManager.IsDocumentAvailable)
                {
                    Document doc = documentManager.GetDocument();
                    Console.WriteLine("Processing document {0}", doc.Title);
                }
                Thread.Sleep(new Random().Next(20));
            }
        }
    }

    internal class QueueSample
    {
        internal static void QueueMain()
        {
            var dm = new DocumentManager();

            ProcessDocuments.Start(dm);

            // Create documents and add them to the DocumentManager
            for (int i = 0; i < 50; i++)
            {
                Document doc = new Document("Doc " + i.ToString(), "content");
                dm.AddDocument(doc);
                Console.WriteLine("Added document {0}", doc.Title);
                Thread.Sleep(new Random().Next(20));
            }

        }
    }