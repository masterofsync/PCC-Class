import java.util.Scanner;

public class temperature {
	
	public static void main(String[] args)
	{
		Scanner input = new Scanner(System.in);
		int choice = 0;
		float far, cel;
		
		do
		{
			System.out.println("Main Menu:");
			System.out.println("1. Convert to Farenheit");
			System.out.println("2. Convert to Celcius");
			System.out.println("3. Exit");
			System.out.println("Enter Choice: ");
			choice = input.nextInt();
			
			if(choice == 1)
			{
				System.out.println("Enter Celcius value: ");
				cel = input.nextFloat();
				System.out.println("Farenheit value = " + tofarenheit(cel));
				
			}
			
			if(choice == 2)
			{
				System.out.println("Enter Farenheit value: ");
				far = input.nextFloat();
				System.out.println("Celcius value = " + tocelsius(far));
			}
			
			if(choice == 3)
			{
				System.out.println("Thank You for using this program!");
			}
		}while(choice !=3);
	}
	
	public static float tocelsius(float farenheit)
	{
		float data = (float) ((5.0 / 9.0) * ( farenheit - 32.0 ));
		return data;
	}

	public static float tofarenheit(float celsius)
	{
		
		float data = (float)((9.0 / 5.0) * celsius + 32);
		return data;
	}
}
