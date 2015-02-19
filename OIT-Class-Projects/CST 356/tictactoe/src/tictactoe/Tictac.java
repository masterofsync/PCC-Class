package tictactoe;
import java.util.Scanner;

public class Tictac 
{
	public static void main(String args[])
	{
		char[] data = new char[9];
		Scanner input = new Scanner(System.in);
		char play;
		data = new char[] {'1','2','3','4','5','6','7','8','9'};
		
		do
		{
			System.out.println("Do you want to play(y/n)?");
			play = input.next().charAt(0);
		
			if(play == 'y')
			{
				startgame(data);
			}
		}while(play =='y');
		System.out.println("Thank You for using this Program");
	}
	
	public static int checker(char[]data)
	{
		if(data[0] == 'X' && data[1] == 'X' && data[2]== 'X'|| data[3] == 'X' && data[4] == 'X' && data[5]== 'X' || data[6] == 'X'&&data[7] == 'X' && data[8]== 'X' || data[0] == 'X' && data[3] == 'X' && data[6]== 'X' || data[1] == 'X' && data[4] == 'X' && data[7]== 'X'||data[2] == 'X' && data[5] == 'X' && data[8]== 'X'||data[0] == 'X'&& data[4] == 'X' && data[8]== 'X' || data[2] == 'X'&&data[4] == 'X' && data[6]== 'X')
		{
			return 1;
		}
		else if( data[0] == 'O' && data[1] == 'O' && data[2]== 'O' || data[3] == 'O' && data[4] == 'O' && data[5]== 'O' || data[6] == 'O' && data[7] == 'O' && data[8]== 'O' || data[0] == 'O' && data[3] == 'O' && data[6]== 'O' || data[1] == 'O' && data[4] == 'O' &&data[7]== 'O' || data[2] == 'O' && data[5] == 'O' && data[8]== 'O'||data[0] == 'O' && data[4] == 'O' && data[8]== 'O'||data[2] == 'O'&& data[4] == 'O' && data[6]== 'O')
		{
			return 2;
		}
		else if(data[0] == '1' || data[1] =='2' || data[2] == '3' || data[3] =='4' || data[4] == '5' || data[5] =='6' || data[6] == '7' || data[7] == '8' || data[8] =='9')
		{
			return 3;
		}
		else 
		{
			return 0;
		}
	}
	
	public static void startgame(char []data)
	{
		Scanner input = new Scanner(System.in);
		char player1;
		
		char player2;
		int check = 0;
		display(data);
		
		while(checker(data) == 0 || checker(data) == 3)
		{
			System.out.println("Player 1's move: ");
			check = 0;
			while(check ==0)
			{
				player1 = input.next().charAt(0);
				if(player1 == '1' ||player1 == '2'||player1 == '3'||player1 == '4'||player1 == '5'||player1 == '6'||player1 == '7'||player1 == '8'||player1 == '9')
				{
					if(player1 == '1' && data[0] !='0' && data[0] != 'O')
					{
						check = 1;
						data[0] = 'X';
					}
					else if(player1 == '2'&& data[1] !='0'&& data[1] !='O')
					{
						check = 1;
						data[1] = 'X';
					}
					else if(player1 == '3' && data[2] !='0'&& data[2] !='O')
					{
						check = 1;
						data[2] = 'X';
					}
					else if(player1 == '4' && data[3] !='0'&& data[3] !='O')
					{
						check = 1;
						data[3] = 'X';
					}
					else if(player1 == '5' && data[4] !='0'&& data[4] !='O')
					{
						check = 1;
						data[4] = 'X';
					}
					else if(player1 == '6' && data[5] !='O' && data[5] != 'O')
					{
						check = 1;
						data[5] = 'X';
					}
					else if(player1 == '7' && data[6] !='O' && data[6] != 'O')
					{
						check = 1;
						data[6] = 'X';
					}
					else if(player1 == '8' && data[7] !='O' && data[7] != 'O')
					{
						check = 1;
						data[7] = 'X';
					}
					else if(player1 == '9' && data[8] !='O' && data[8] != 'O')
					{
						check = 1;
						data[8] = 'X';
					}
					else
					{
						System.out.println("Please choose a different spot(Player1):");
					}				
				}
				else
				{
					System.out.println("Please choose a number between 1-9!");
				}
				
			}	
			
			display(data);
			
			if(checker(data) == 1)
			{
				System.out.println("Congratulation! Player 1 wins!");
			}
			else
			{
				System.out.println("Player 2's move: ");
				check = 0;
				while(check ==	0)
				{
					player2 = input.next().charAt(0);
			
					if(player2 == '1' ||player2 == '2'||player2 == '3'||player2 == '4'||player2 == '5'||player2 == '6'||player2 == '7'||player2 == '8'||player2 == '9')
					{				
						if(player2 == '1' && data[0] !='X' && data[0] != 'X')
						{
							data[0] = 'O';
							check = 1;
						}
						else if(player2 == '2' && data[1] !='X' && data[1] != 'X')
						{
							data[1] = 'O';
							check = 1;
						}
						else if(player2 == '3' && data[2] !='X' && data[2] != 'X')
						{
							data[2] = 'O';
							check = 1;
						}
						else if(player2 == '4' && data[3] !='X' && data[3] != 'X')
						{
							data[3] = 'O';
							check = 1;
						}
						else if(player2 == '5' && data[4] !='X' && data[4] != 'X')
						{
							data[4] = 'O';
							check = 1;
						}
						else if(player2 == '6' && data[5] !='X' && data[5] != 'X')
						{
							data[5] = 'O';
							check = 1;
						}
						else if(player2 == '7' && data[6] !='X' && data[6] != 'X')
						{
							data[6] = 'O';
							check = 1;
						}
						else if(player2 == '8' && data[7] !='X' && data[7] != 'X')
						{
							data[7] = 'O';
							check = 1;
						}
						else if(player2 == '9' && data[8] !='X' && data[8] != 'X')
						{
							data[8] = 'O';
							check = 1;
						}		
						else
						{
							System.out.println("Please choose a different spot(Player2):");
						}
					}
					else 
					{
						System.out.println("Please choose a number from 1-9!");
					}
					
					display(data);
				}
			}
			
			if(checker(data) == 2)
			{
				display(data);
				System.out.println("Congratulaton! Player 2 wins!");
			}
		}
	}
	
	public static void display(char [] data)
	{
		System.out.println(data[0] + "|" + data[1] + "|" + data[2]);
		System.out.println("-" + "+" + "-" + "+" + "-");
		System.out.println(data[3] + "|" + data[4] + "|" + data[5]);
		System.out.println("-" + "+" + "-" + "+" + "-");
		System.out.println(data[6] + "|" + data[7] + "|" + data[8]);	
	}
}
