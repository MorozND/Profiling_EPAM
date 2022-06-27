using System.Security.Cryptography;
using System.Text;

var password = "qwerty";
var salt = "akfncheurkfhjdpe";
var saltBytes = Encoding.UTF8.GetBytes(salt);

Console.WriteLine($"Password: {password}");
Console.WriteLine($"Salt: {salt}");

var hash = GeneratePasswordHashUsingSalt(password, saltBytes);

Console.WriteLine($"\nHash: {hash}");

string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
{
    var iterate = 10000;
    var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
    byte[] hash = pbkdf2.GetBytes(20);

    byte[] hashBytes = new byte[36];
    Buffer.BlockCopy(salt, 0, hashBytes, 0, 16);
    Buffer.BlockCopy(hash, 0, hashBytes, 16, 20);

    return Encoding.UTF8.GetString(hashBytes);
}
