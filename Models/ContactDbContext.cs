namespace ContactManagement.Models
{
    // Keep this for compatibility but use file storage instead
    public class ContactDbContext
    {
        private readonly ContactRepository _repository;

        public ContactDbContext(IWebHostEnvironment environment)
        {
            _repository = new ContactRepository(environment);
        }

        public ContactDbContext(ContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            return await _repository.CreateAsync(contact);
        }

        public async Task<bool> UpdateContactAsync(Contact contact)
        {
            return await _repository.UpdateAsync(contact);
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<Contact>> SearchContactsAsync(string searchTerm)
        {
            return await _repository.SearchAsync(searchTerm);
        }

        // Keep DbSet for compatibility with existing code
        public object Contacts => null!;
    }
}
