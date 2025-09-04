import java.io.*;
import java.math.*;
import java.security.*;
import java.text.*;
import java.util.*;
import java.util.concurrent.*;
import java.util.function.*;
import java.util.regex.*;
import java.util.stream.*;
import static java.util.stream.Collectors.joining;
import static java.util.stream.Collectors.toList;

class Result {
    public static int equalizeArray(List<Integer> arr) {
        
        List<Integer> sortedArr = new ArrayList<>(arr);
        Collections.sort(sortedArr);
        
        int maxFreq = 1;
        int currentFreq = 1;
        int currentNum = sortedArr.get(0);
        
        for (int i = 1; i < sortedArr.size(); i++) {
            if (sortedArr.get(i).equals(currentNum)) {
                currentFreq++;
                maxFreq = Math.max(maxFreq, currentFreq);
            } else {
                currentNum = sortedArr.get(i);
                currentFreq = 1;
            }
        }
        
        return arr.size() - maxFreq;
    }

}

public class EqualizeTheArray {
    public static void main(String[] args) throws IOException {
        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(System.in));
        BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(System.getenv("OUTPUT_PATH")));

        int n = Integer.parseInt(bufferedReader.readLine().trim());

        List<Integer> arr = Stream.of(bufferedReader.readLine().replaceAll("\\s+$", "").split(" "))
            .map(Integer::parseInt)
            .collect(toList());

        int result = Result.equalizeArray(arr);

        bufferedWriter.write(String.valueOf(result));
        bufferedWriter.newLine();

        bufferedReader.close();
        bufferedWriter.close();
    }
}

