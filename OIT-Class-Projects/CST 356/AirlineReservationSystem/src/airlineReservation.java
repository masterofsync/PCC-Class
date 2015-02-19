import java.util.Scanner;


public class airlineReservation 
{
	
	public static void main(String[] args)
	{
		boolean checkType1 = false, checkType2 = false;
		char choose = 'n';
		int seatType;
		int count = 0;
		Scanner input = new Scanner(System.in);
		char reserve = 'n';
		String type = null;
		int seats =2;
		
		boolean [] arraydata = new boolean[11];
		
		for(int i =1;i<11;i++)
		{
			arraydata[i] = false;
		
		}
		
		do
		{
			System.out.println("Please type 1 for first class ticket or 2 for economy class ticket: ");
			seatType = input.nextInt();
			seats = 0;
			for(int i=1;i<11;i++)
			{
				if(arraydata[i] == false)
				{
					seats+=1;
				}
			}
			do
			{
				
				
					if(seatType == 1)
					{
						checkType1 = false;
						count = 0;
						do
						{
							if(count<5)
							{
								count++;
								if(arraydata[count] == false)
								{
									arraydata[count] = true;
									type = "First Class";
									checkType1 = true;
								}
							}
							else
							{
								System.out.println("No seats available for First Class. Reserve Economy class?(y/n): ");
								choose = input.next().charAt(0);
								if(choose == 'y')
								{
									if(seats !=0)
									{
										seatType = 2;
									}
									checkType1 = false;
								}
								count = 6;
							}
						}while(checkType1 != true && count < 6);	
					}
					else if(seatType == 2)
					{
						checkType2 = false;
						count = 5;
						do
						{
							if(count<10)
							{
								count++;
								if(arraydata[count] == false)
								{
									arraydata[count] = true;
									type = "Economy";
									checkType2 = true;
								}
							}
							else
							{
								System.out.println("No seats available for Economy Class. Reserve First class?(y/n): ");
								choose = input.next().charAt(0);
								if(choose == 'y')
								{
									if(seats != 0)
									{
										seatType = 1;
									}
									checkType2 = false;
								}
								count = 11;
							}
						}while(checkType2 != true && count < 11);
					}
					
					
					if(seats == 0)
					{
						System.out.println("No seat available. Sorry!");
						choose = 'n';
					}
					else if(checkType1 == true)
					{
						choose = 'n';
					}
					else if(checkType2 == true)
					{
						choose = 'n';
					}
					
				}while(choose == 'y');
				
			for(int i =1;i<=10;i++)
			{
				if(arraydata[i] == true)
				{
					System.out.println("Seat no. "+ i +" is reserved");
				
				}
			}
			
			if(seats !=0)
			{
				System.out.println("Next flight leaves in 3 hours");
				
				if(checkType1 != false || checkType2 != false)
				{
					System.out.println("Boarding Pass: Seat No." + (count) +" Type: " + type);
				}
			System.out.println("Would you like to reserve another ticket?(y/n)");
			reserve = input.next().charAt(0);
			}
			else if(seats == 0)
			{
				reserve ='n';
			}
			
		}while(reserve == 'y');	
		
		System.out.println("Thank You for using the program!");
	}
}
