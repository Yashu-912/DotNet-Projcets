public class Document1
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public byte Priority { get; private set; }

        public Document1(string title, string content, byte priority = 0)
        {
            this.Title = title;
            this.Content = content;
            this.Priority = priority;
        }
    }


    public class PriorityDocumentManager
    {
        private readonly LinkedList<Document1> documentList;

        // priorities 0.9
        private readonly List<LinkedListNode<Document1>> priorityNodes;

        public PriorityDocumentManager()
        {
            documentList = new LinkedList<Document1>();

            priorityNodes = new List<LinkedListNode<Document1>>(10);
            for (int i = 0; i < 10; i++)
            {
                priorityNodes.Add(new LinkedListNode<Document1>(null));
            }
        }

        public void AddDocument(Document1 d)
        {
            if (d == null) throw new ArgumentNullException("d");

            AddDocumentToPriorityNode(d, d.Priority);
        }

        private void AddDocumentToPriorityNode(Document1 doc, int priority)
        {
            if (priority > 9 || priority < 0)
                throw new ArgumentException("Priority must be between 0 and 9");

            if (priorityNodes[priority].Value == null)
            {
                --priority;
                if (priority >= 0)
                {
                    // check for the next lower priority
                    AddDocumentToPriorityNode(doc, priority);
                }
                else // now no priority node exists with the same priority or lower
                // add the new document to the end
                {
                    documentList.AddLast(doc);
                    priorityNodes[doc.Priority] = documentList.Last;
                }
                return;
            }
            else // a priority node exists
            {
                LinkedListNode<Document1> prioNode = priorityNodes[priority];
                if (priority == doc.Priority)
                // priority node with the same priority exists
                {
                    documentList.AddAfter(prioNode, doc);

                    // set the priority node to the last document with the same priority
                    priorityNodes[doc.Priority] = prioNode.Next;
                }
                else // only priority node with a lower priority exists
                {
                    // get the first node of the lower priority
                    LinkedListNode<Document1> firstPrioNode = prioNode;

                    while (firstPrioNode.Previous != null &&
                       firstPrioNode.Previous.Value.Priority == prioNode.Value.Priority)
                    {
                        firstPrioNode = prioNode.Previous;
                        prioNode = firstPrioNode;
                    }

                    documentList.AddBefore(firstPrioNode, doc);

                    // set the priority node to the new value
                    priorityNodes[doc.Priority] = firstPrioNode.Previous;
                }
            }
        }

        public void DisplayAllNodes()
        {
            foreach (Document1 doc in documentList)
            {
                Console.WriteLine("priority: {0}, title {1}", doc.Priority, doc.Title);
            }
        }

        // returns the document with the highest priority
        // (that's first in the linked list)
        public Document1 GetDocument()
        {
            Document1 doc = documentList.First.Value;
            documentList.RemoveFirst();
            return doc;
        }

    }


    internal class LinkedListSample {

        internal static void LinkedListMain() {

            PriorityDocumentManager pdm = new PriorityDocumentManager();
            pdm.AddDocument(new Document1("one", "Sample", 8));
            pdm.AddDocument(new Document1("two", "Sample", 3));
            pdm.AddDocument(new Document1("three", "Sample", 4));
            pdm.AddDocument(new Document1("four", "Sample", 8));
            pdm.AddDocument(new Document1("five", "Sample", 1));
            pdm.AddDocument(new Document1("six", "Sample", 9));
            pdm.AddDocument(new Document1("seven", "Sample", 1));
            pdm.AddDocument(new Document1("eight", "Sample", 1));

            pdm.DisplayAllNodes();
        }
    }