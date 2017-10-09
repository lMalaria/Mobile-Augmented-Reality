using System;
using System.Text;

namespace HashTableProject
{
    class CHashTable
    {
       private const int tablesize = 1000;
       public class item{
           
           public string key;
           public string value;
           public item next;
       }

        item[] HashTable = new item[tablesize];
        
     


      
        public int Hash(string key)
        {
            int hash = 0;
            int index;
        
            for (int i = 0; i < key.Length; i++)
            {
                hash = (hash + (int)key[i]);
            }
            
            index = hash % tablesize;
            
            return index;
        }
        public int reHash(string key)
        {
            int rehash = 0;
            int reindex;

            for(int i = 0; i < key.Length; i++)
            {
                rehash = (rehash + (int)key[i]) * 17;
            }
            
            reindex = rehash % tablesize;

            return reindex;
        }
        public CHashTable()
        {
            for (int i = 0; i < tablesize; i++)
            {
                HashTable[i] = new item();
                HashTable[i].key = "empty";
                HashTable[i].value = "empty";
                HashTable[i].next = null;
            }
        }

        public void AddItem()
        {
            int chkCount = 0;
            int[] itemNum = new int[tablesize];
            Console.Write("key:");
            string key = Console.ReadLine();
            Console.Write("value:");
            string value = Console.ReadLine();

            int index = Hash(key);

            if (HashTable[index].key == "empty")
            {
                HashTable[index].key = key;
                HashTable[index].value = value;
            }

            else if(HashTable[index].key != "empty")
            {
                NumberOfItemsInIndex(index);

                if(NumberOfItemsInIndex(index) < 5 )
                {
                    item Ptr = HashTable[index];
                    item n = new item();
                    n.key = key;
                    n.value = value;
                    n.next = null;

                    while (Ptr.next != null)
                    {   
                        Ptr = Ptr.next;
                    }
                    Ptr.next = n;
                }

                else
                {

                    chkCount++;

                    if(chkCount < 2)
                    {
                        Console.WriteLine("아이템이 꽉차서 새롭게 해싱합니다.");
                        Console.Write("key: ");
                        Console.Write(key);
                        Console.Write(" ");
                        Console.Write("value: ");
                        Console.WriteLine(value);
                        
                        index = reHash(key);
                        
                        if(HashTable[index].key == "empty")
                        {
                            HashTable[index].key = key;
                            HashTable[index].value = value;
                        }
                        
                        else if(HashTable[index].key != "empty")
                        {
                            NumberOfItemsInIndex(index);
                            if(NumberOfItemsInIndex(index) < 5 )
                            {
                                item Ptr2 = HashTable[index];
                                item n2 = new item();
                                n2.key = key;
                                n2.value = value;
                                n2.next = null;

                                while (Ptr2.next != null)
                                {   
                                    Ptr2 = Ptr2.next;
                                }   
                                Ptr2.next = n2;
                                chkCount = 0;
                            }
                        
                        }

                        else
                        {
                            Console.WriteLine("더이상 해싱 불가.");
                            chkCount = 0;
                        }
                    }

                    else
                    {
                        Console.WriteLine("더이상 해싱도 불가능합니다.");
                        chkCount = 0;
                    }

                }
            }

        }

        public int NumberOfItemsInIndex(int index)
        {
            
            int count = 0;
            
            if (HashTable[index].key == "empty")
            {
                return count;
            }

            else if(HashTable[index].key != "empty")
            {
                if(count < 5)
                {
                    count++;
                    item Ptr = HashTable[index];
                
                    while (Ptr.next != null)
                    {
                        count++;
                        Ptr = Ptr.next;
                    }
                }

                else
                {
                    count = 5;
                }
            }

            return count;
        }

        public void PrintTable()
        {
            int number;
            for (int i = 0; i < tablesize; i++)
            {
                number = NumberOfItemsInIndex(i);
                Console.WriteLine("----------------------");
                Console.Write("index = "); 
                Console.WriteLine(i);
                Console.WriteLine(HashTable[i].key);
                Console.WriteLine(HashTable[i].value);
                Console.Write("Number of items = "); 
                Console.WriteLine(number);
                Console.WriteLine("----------------------");
            }

        }

        public void PrintTableInIndex()
        {
            string line = Console.ReadLine();
            int index = int.Parse(line);

            item Ptr = HashTable[index];

            if (Ptr.key == "empty")
            {
                Console.Write("index = "); 
                Console.Write(index);
                Console.WriteLine(" is empty");
            }

            else
            {
                Console.Write(" index "); 
                Console.Write(index); 
                Console.WriteLine(" contains the following item");

                while (Ptr != null)
                {
                    Console.WriteLine("-----------------");
                    Console.WriteLine(Ptr.key);
                    Console.WriteLine(Ptr.value);
                    Console.WriteLine("-----------------");
                    Ptr = Ptr.next;
                }
            }
        }

        public void Search()
        {
            string key = Console.ReadLine();
            
            int index = Hash(key);
            int reindex = reHash(key);
            bool foundName = false;
            string value;

            item Ptr = HashTable[index];
            item Ptr2 = HashTable[reindex];
        
            while(Ptr != null)
            {
                if (Ptr.key == key)
                {
                    foundName = true;
                    value = Ptr.value;

                }
                Ptr = Ptr.next;
            }

            if (foundName == true)
            {
                Console.WriteLine(HashTable[index].value);
            }
        
            else
            {
                Console.WriteLine("null");
            }

      
        }

        public void RemoveItem(string key)
        {
            int index = Hash(key);
            item delPtr;
            item P1;
            item P2;

            if (HashTable[index].key == "empty" && HashTable[index].value == "empty")
            {
                Console.WriteLine("null");
            }

            else if (HashTable[index].key == key && HashTable[index].next == null)
            {
                HashTable[index].key = "empty";
                HashTable[index].value = "empty";
                Console.Write("'");
                Console.Write(key);
                Console.Write("' ");
                Console.WriteLine("was removed from the hash");
            }


            else if (HashTable[index].key == key)
            {
                delPtr = HashTable[index];
                HashTable[index] = HashTable[index].next;
                delPtr = null;

                Console.Write("'");
                Console.Write(key);
                Console.Write("' ");
                Console.WriteLine(" was removed from the hash.");
            }

            else
            {
                P1 = HashTable[index].next;
                P2 = HashTable[index];

                while (P1 != null && P1.key != key)
                {
                    P2 = P1;
                    P1 = P1.next;
                }

                if (P1 == null)
                {
                    Console.WriteLine("null"); 
                }
            
                else
                {
                    delPtr = P1;
                    P1 = P1.next;
                    P2.next = P1;

                    delPtr = null;
                    Console.Write("'");
                    Console.Write(key);
                    Console.Write("' ");
                    Console.WriteLine("was removed from the hash table");
                }
            }
        
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CHashTable Hashy = new CHashTable();
	        string key;

            while (true)
            {

                Console.WriteLine("원하는 기능을 선택하세요");
                Console.WriteLine("1.Confirm");
                Console.WriteLine("2.Add    ");
                Console.WriteLine("3.Index"); 
                Console.WriteLine("4.Delete"); 
                Console.WriteLine("5.Search");


                string line = Console.ReadLine();
                int select = int.Parse(line);

                if (select == 1)
                {
                    Hashy.PrintTable();
                }

                else if (select == 2)
                {
                    Hashy.AddItem();
                }

                else if (select == 3)
                {

                    Console.Write("자세히 보고싶은 index 선택:");
                    Hashy.PrintTableInIndex();
                }

                else if (select == 4)
                {
                    Console.Write("지우기 원하는 키값을 입력하세요:");
                    key = Console.ReadLine();
                    Hashy.RemoveItem(key);
                }

                else if (select == 5)
                {
                    Console.Write("찾고 싶은 값의 키값을 입력하세요:");
                    Hashy.Search();
                }

            }
        
        }
    }
}
