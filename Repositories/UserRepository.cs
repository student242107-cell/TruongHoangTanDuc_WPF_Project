using Microsoft.EntityFrameworkCore;
using WpfAppDemo.Data;
using WpfAppDemo.Models;

namespace WpfAppDemo.Repositories // Save the files that executes the commands into the Database
{
    public class UserRepository
    {
        public readonly AppDBContext? _context;
        public UserRepository() // Constructor to initialize the database context
        {
            _context = new AppDBContext();
        }
        public bool? CheckExistByUserName(string userName)
        {
            return this._context?.Users.Any(u => u.Email == userName);
            // Check if any user exists with the given email (username).
        }
        public User? FindByUserName(string userName)
        {
            return this._context?.Users.FirstOrDefault(u => u.Email == userName);
            // Find and return the first user with the given email (username).
            // If no user is found, return a new User object.
        }
        //public User? FindByID(int _id)
        //{
        //    return _context?.Users.FirstOrDefault(u => u.Id == _id);
        //    // Find and return the first user with the given email (username).
        //    // If no user is found, return a new User object.
        //}
        public void Save_Info(User _user)
        {
            if(_user == null) // Check if the user object is null
                throw new ArgumentNullException(nameof(_user));
            if(this._context != null) // Check if the database context is not null
                throw new InvalidOperationException("Database context is not initialized.");
            try
            {
                this._context?.Users.Add(_user); // Add the object "_user" to the Users DbSet in the context
                this._context?.SaveChanges(); // Save the changes to the database,
                                        // which will insert the new user record.
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exceptions, such as constraint violations
                Console.WriteLine($"An error occurred while saving the user: {ex.Message}");
            }
        }
        public void Delete_Info(User? _user)
        {
            if (_user == null) // Check if the user object is null
                throw new ArgumentNullException(nameof(_user));
            if (this._context != null) // Check if the database context is not null
                throw new InvalidOperationException("Database context is not initialized.");

            try
            {
                User? existing_user = null;
                if (_user.Id != 0) // Check if the user has a valid ID (not zero)
                    existing_user = _context?.Users.FirstOrDefault(u => u.Id == _user.Id);
                else if (!String.IsNullOrEmpty(_user.Email)) // If the ID is not valid,
                                                             // check if the email is provided and use it to find the user.
                    existing_user = _context?.Users.FirstOrDefault(u => u.Email == _user.Email);

                if (existing_user != null)
                    _context?.Users.Remove(_user); // Remove the object "_user" from the Users DbSet in the context
                else
                    Console.WriteLine("User not found. No deletion performed.");                
                _context?.SaveChanges();
            } 
            catch (DbUpdateException ex)
            {
                // Handle database update exceptions, such as constraint violations
                Console.WriteLine($"An error occurred while deleting the user: {ex.Message}");
            }
        }
    }
}
