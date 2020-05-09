import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        var input = Integer.parseInt(console.nextLine());
       
        
        if (input % 2 == 0) {
        	 var numberAfterDivisionByTwo = input / 2;
        	 var numberAfterDivisonByTwoMinusTwo = (input - 2) / 2;
        	 if ((numberAfterDivisionByTwo % 2 == 0 || ((numberAfterDivisonByTwoMinusTwo % 2) == 0)) && input != 2) {
        		 System.out.println("YES");
			}
        	 else {
        		 System.out.println("No");
        	 }
		}
        else {
			System.out.println("No");
        }
	}

}
