using System;
using LibGit2Sharp;

namespace CloneAndCheckout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string repositoryUrl = "https://github.com/SumanthBabu4/Demo.git";
            string localPath = "C:\\Users\\Saleti.Babu\\Downloads\\GitUpdate";
            string branchName = "main";
            // Clone the repository
            Repository.Clone(repositoryUrl, localPath);

            // Open the cloned repository
            using (var repo = new Repository(localPath))
            {
                // Checkout the desired branch
                var branch = repo.Branches[branchName];
                if (branch != null)
                {
                    // Get the tip (latest commit) of the branch
                    var commit = branch.Tip;

                    // Checkout the branch
                    Commands.Checkout(repo, commit, new CheckoutOptions
                    {
                        CheckoutModifiers = CheckoutModifiers.Force
                        
                    });
                }
                else
                {
                    throw new ArgumentException($"Branch '{branchName}' not found.");
                }
                Console.WriteLine("Hello World!");
            }
        }
    }
}
