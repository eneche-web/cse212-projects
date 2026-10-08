
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character
    /// words (lower case, no duplicates). Using sets, find an O(n)
    /// solution for returning all symmetric pairs of words.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var pairs = new List<string>();

        foreach (var word in words)
        {
            string reversed = new string(word.Reverse().ToArray());

            if (word != reversed && wordSet.Contains(reversed))
            {
                pairs.Add($"{word} & {reversed}");

                wordSet.Remove(word);
                wordSet.Remove(reversed);
            }
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees earned
    /// by the people contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if two words are anagrams.
    /// Spaces and letter case are ignored.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var letters = new Dictionary<char, int>();

        foreach (char character in word1)
        {
            if (character == ' ')
            {
                continue;
            }

            char letter = char.ToLower(character);

            if (letters.ContainsKey(letter))
            {
                letters[letter]++;
            }
            else
            {
                letters[letter] = 1;
            }
        }

        foreach (char character in word2)
        {
            if (character == ' ')
            {
                continue;
            }

            char letter = char.ToLower(character);

            if (!letters.ContainsKey(letter))
            {
                return false;
            }

            letters[letter]--;

            if (letters[letter] < 0)
            {
                return false;
            }
        }

        foreach (var count in letters.Values)
        {
            if (count != 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Read the current day's earthquake data from the USGS
    /// and return the location and magnitude of each earthquake.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var earthquakes = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                if (feature.Properties != null)
                {
                    string place = feature.Properties.Place ?? "Unknown location";
                    double magnitude = feature.Properties.Mag ?? 0;

                    earthquakes.Add($"{place} - Magnitude {magnitude}");
                }
            }
        }

        return earthquakes.ToArray();
    }
}