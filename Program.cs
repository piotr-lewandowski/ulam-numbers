using System.Text;

// Last number to check is the command line param
var n = int.Parse(args[0]);

// Count in how many ways it is possible to represent the index as a sum of two previous Ulam sequence numbers
var possibilities = new int[n + 1];

// Start the sequence with 1 and 2
possibilities[1] = 1;
possibilities[2] = 1;

int toAdd = 2;

while (toAdd != 0)
{
    // Combine the new element with the preceding sequence
    for (int i = 1; i < toAdd; ++i)
    {
        if (possibilities[i] == 1)
        {
            var newCombination = i + toAdd;
            if (newCombination <= n)
                possibilities[newCombination] += 1;
            else
                break;
        }
    }

    // Find the smallest element of the sequence larger than the current one
    var start = toAdd + 1;
    toAdd = 0;
    for (int i = start; i <= n; ++i)
    {
        if (possibilities[i] == 1)
        {
            toAdd = i;
            break;
        }
    }
}

// Print the result to a file
var sb = new StringBuilder();

for (int i = toAdd + 1; i <= n; ++i)
{
    if (possibilities[i] == 1)
    {
        sb.AppendLine(i.ToString());
    }
}
File.WriteAllText("ulam_numbers.txt", sb.ToString());