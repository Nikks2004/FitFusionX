using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SportNutr.Domain;

namespace SportNutr.BL
{
    public class CredentialManager
    {
        private readonly IStoreRepository _repository;

        public CredentialManager(IStoreRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Client ConfirmCredentials(string identity, string secret)
        {
            var clientProfile = _repository.Query<Client>().FirstOrDefault(profile => profile.Username == identity);
            if (clientProfile != null && SecretIsValid(secret, clientProfile.SecretHash))
            {
                return clientProfile;
            }
            return null;
        }

        public bool HasRequiredPrivilege(Client profile, string privilege)
        {
            return profile.Privilege.Equals(privilege, StringComparison.OrdinalIgnoreCase);
        }

        public Client EnrollClient(string identity, string secret)
        {
            var secretHash = ProtectSecret(secret);

            var newClient = new Client
            {
                Username = identity,
                SecretHash = secretHash,
                Privilege = "Standard" // Default privilege
            };

            _repository.Add(newClient);
            _repository.CommitChanges();

            return newClient;
        }

        private byte[] ProtectSecret(string secret)
        {
            using (var hasher = new SHA256Managed())
            {
                return hasher.ComputeHash(Encoding.UTF8.GetBytes(secret));
            }
        }

        private bool SecretIsValid(string secret, byte[] expectedHash)
        {
            var trialHash = ProtectSecret(secret);
            return trialHash.SequenceEqual(expectedHash);
        }
    }
}