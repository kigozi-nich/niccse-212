using System.Text.Json;
using System.Net.Http;

public static class SetsAndMaps
{
    // Problem 1 - Symmetric Pairs
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();
        foreach (var word in words)
        {
            if (word[0] == word[1]) continue;
            var reversed = new string(new char[] { word[1], word[0] });
            if (wordSet.Contains(reversed))
            {
                var pair = $"{word} & {reversed}";
                if (!result.Contains(pair) && !result.Contains($"{reversed} & {word}"))
                    result.Add(pair);
            }
        }
        return result.ToArray();
    }

    // Problem 2 - Degree Summary
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length < 4) continue;
            var degree = fields[3].Trim();
            if (degrees.ContainsKey(degree)) degrees[degree]++;
            else degrees[degree] = 1;
        }
        return degrees;
    }

    // Problem 3 - Anagram
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();
        if (word1.Length != word2.Length) return false;

        var dict = new Dictionary<char, int>();
        foreach (var c in word1)
            dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
        foreach (var c in word2)
        {
            if (!dict.ContainsKey(c) || dict[c] == 0) return false;
            dict[c]--;
        }
        return true;
    }

    // Problem 5 - Earthquake JSON Data
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        return featureCollection.Features
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
            .ToArray();
    }
}
