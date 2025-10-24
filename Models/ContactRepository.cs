using System.Text.Json;

namespace ContactManagement.Models
{
    public class ContactRepository
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public ContactRepository(IWebHostEnvironment environment)
        {
            var dataPath = Path.Combine(environment.ContentRootPath, "Data");
            Directory.CreateDirectory(dataPath);
            _filePath = Path.Combine(dataPath, "contacts.json");

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Contact>();
            }

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Contact>>(json, _jsonOptions) ?? new List<Contact>();
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            var contacts = await GetAllAsync();
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        public async Task<Contact> CreateAsync(Contact contact)
        {
            var contacts = await GetAllAsync();

            // Generate new ID
            contact.Id = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1;

            contacts.Add(contact);
            await SaveAllAsync(contacts);
            return contact;
        }

        public async Task<bool> UpdateAsync(Contact contact)
        {
            var contacts = await GetAllAsync();
            var existingContact = contacts.FirstOrDefault(c => c.Id == contact.Id);

            if (existingContact == null)
                return false;

            // Update properties
            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.Email = contact.Email;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.Address = contact.Address;

            await SaveAllAsync(contacts);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contacts = await GetAllAsync();
            var contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
                return false;

            contacts.Remove(contact);
            await SaveAllAsync(contacts);
            return true;
        }

        public async Task<List<Contact>> SearchAsync(string searchTerm)
        {
            var contacts = await GetAllAsync();

            if (string.IsNullOrEmpty(searchTerm))
                return contacts;

            return contacts.Where(c =>
                c.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.PhoneNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        private async Task SaveAllAsync(List<Contact> contacts)
        {
            var json = JsonSerializer.Serialize(contacts, _jsonOptions);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
