using CoreLibrary;
using DataLibrary;
using DataLibrary.Implementations;


namespace Manage.Controllers
{
    public class ContactController
    {
        Contact contact = new Contact();
        private ContactRepository _contactRepository;
        public ContactController()
        {
            _contactRepository = new ContactRepository();
        }
        #region Create
        public void Create()
        {
            ConsoleHelper.WriteWithColor(ConsoleColor.DarkYellow, "Please, enter the name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor(ConsoleColor.DarkYellow, "Please enter the surname");
            string surname = Console.ReadLine();
        WriteCorrectNumber: ConsoleHelper.WriteWithColor(ConsoleColor.DarkYellow, "Please enter the number");
            string number = Console.ReadLine();
            int num;
            bool result = int.TryParse(number, out num);
            if (result)
            {
                contact.Name = name;
                contact.Surname = surname;
                contact.Number = num;
                _contactRepository.Create(contact);
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkGreen, $"Contact Name is{contact.Name}, Id is {contact.Id.ToString()}");


            }
            else
            {
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "Please, type the correct number");
                goto WriteCorrectNumber;
            }

        }
        #endregion
        #region Update
        public void Update()
        {
            var contacts = _contactRepository.GetAll();
            if (contacts.Count != 0)
            {
            WritingCorrectId: ConsoleHelper.WriteWithColor(ConsoleColor.DarkMagenta, "Please, choose one of the displayed contact id to update");
                foreach (var contact in contacts)
                {
                    ConsoleHelper.WriteWithColor(ConsoleColor.DarkGreen, $"Contact Name is{contact.Name}, Id is {contact.Id.ToString()}");

                }
                string contactId = Console.ReadLine();
                int id;
                bool result = int.TryParse(contactId, out id);
                if (result)
                {
                    var conId = _contactRepository.Get(c => c.Id == id);
                    if (conId != null)
                    {
                        ConsoleHelper.WriteWithColor(ConsoleColor.Blue, "please type new contact name");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteWithColor(ConsoleColor.Blue, "please type new contact Surname");
                        string newSurname = Console.ReadLine();
                    WritingCorrectDigits: ConsoleHelper.WriteWithColor(ConsoleColor.Blue, "please type new contact number");
                        string newNumber = Console.ReadLine();
                        int newNum;
                        result = int.TryParse(newNumber, out newNum);
                        if (result)
                        {
                            contact.Number = newNum;
                            contact.Name = newName;
                            contact.Surname = newSurname;
                            _contactRepository.Update(contact);
                            ConsoleHelper.WriteWithColor(ConsoleColor.DarkYellow, $"New name is {newName}, new surname is {newSurname}, new number is {newNumber}");
                        }
                        else
                        {
                            ConsoleHelper.WriteWithColor(ConsoleColor.Red, "Please enter the correct numbers");
                            goto WritingCorrectDigits;
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "Please enter the right id to continue");
                        goto WritingCorrectId;
                    }
                }
                else
                {
                    ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "Please enter the right id to continue");
                    goto WritingCorrectId;
                }
            }
            else
            {
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "No group found");

            }
        }
        #endregion
        public void Delete()
        {
            var contacts = _contactRepository.GetAll();
            if (contacts.Count != 0)
            {

            TypingCorrectId: ConsoleHelper.WriteWithColor(ConsoleColor.DarkMagenta, "Please choose one of the displayed contact id to remove contact");
                foreach (var contact in contacts)
                {
                    ConsoleHelper.WriteWithColor(ConsoleColor.DarkGreen, $"Contact Name is{contact.Name}, Id is {contact.Id.ToString()}");
                }
                string choosenContact = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(choosenContact, out choosenId);
                if (result)
                {
                    _contactRepository.Delete(contact);
                    ConsoleHelper.WriteWithColor(ConsoleColor.DarkMagenta, "Successfully removed the contact");
                }
                else
                {
                    ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "Please type correct id");
                    goto TypingCorrectId;
                }
            }
            else
            {
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "There is no contact on data");
            }
        }
        #region Get
        public void Get()
        {
            var contacts = _contactRepository.GetAll();
            if (contacts.Count != 0)
            {
            TypingTheCorrectId: ConsoleHelper.WriteWithColor(ConsoleColor.DarkGreen, "Please, choose id to get contact info");
                foreach (var contact in contacts)
                {
                    ConsoleHelper.WriteWithColor(ConsoleColor.DarkGreen, $"Contact Name is{contact.Name}, Id is {contact.Id.ToString()}");
                }
                string contactId = Console.ReadLine();
                int cId;
                bool result = int.TryParse(contactId, out cId);
                if (result)
                {
                    var id = _contactRepository.Get(i => i.Id == cId);
                    if (id != null)
                    {
                        ConsoleHelper.WriteWithColor(ConsoleColor.DarkCyan, $"Contact Name is :{contact.Name}, Contact Surname is{contact.Surname},Contact Number is : {contact.Number}, Contact Id is : {contact.Id}");
                    }
                    else
                    {
                        ConsoleHelper.WriteWithColor(ConsoleColor.Red, "Please type the correct id");
                        goto TypingTheCorrectId;
                    }
                }
                else
                {
                    ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "Type The Correct Id");
                    goto TypingTheCorrectId;
                }

            }
            else
            {
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "There is no contact on data");

            }
        }
        #endregion
        #region GetAll
        public void GetAll()
        {
            var contacts = _contactRepository.GetAll();
            if (contacts.Count != 0)
            {
                foreach (var contact in contacts)
                {
                    ConsoleHelper.WriteWithColor(ConsoleColor.DarkGreen, $"Contact Name is{contact.Name}, Id is {contact.Id.ToString()}");
                }
            }
            else
            {
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "There is no contact on data");
            }
        }
        #endregion
    }
}
