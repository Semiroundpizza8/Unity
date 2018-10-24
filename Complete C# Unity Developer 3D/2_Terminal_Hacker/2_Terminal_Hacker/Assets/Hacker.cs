using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	int level;
	enum Screen { MainMenu, Password, Win };
	Screen currentScreen;
	string[] easyPasswords = {"dogs", "cats", "frogs", "horse", "bunny", "hamster"};
	string[] mediumPasswords = {"porkchop", "meatbone", "hamsammy"};
	string hardPassword = "twilight erotica";
	string password = "";

	// Use this for initialization
	void Start () {
		ShowMainMenu("Benjamin");
	}

	// Displays the main menu, along with a prompt.
	void ShowMainMenu(string name) {
		// Set Screen
		currentScreen = Screen.MainMenu;

		// Screen Written On
		Terminal.ClearScreen();
		Terminal.WriteLine("Hi, " + name + "!");
		Terminal.WriteLine("Where would you like to break into?");
		Terminal.WriteLine("");
		Terminal.WriteLine("Option 1: The Museum of Knowledge.");
		Terminal.WriteLine("Option 2: The Department of Gold.");
		Terminal.WriteLine("Option 3: Space.");
		Terminal.WriteLine("Enter your selection:");
	}

	// Function that runs every time the user hits return.
	// Takes in an input and reacts based on that input.
	void OnUserInput(string input) {
		if(input == "menu" || input == "home") {
			ShowMainMenu("Benjamin");
		} else if(currentScreen == Screen.MainMenu) {
			RunMainMenu(input);
		} else if(currentScreen == Screen.Password) {
			RunPassword(input);
		} else {
			Terminal.WriteLine("Please try a valid option.");
		}
	}

	// Runs whenever an input is left on Screen.MainMenu.
	// Purely the functionality specific to this screen.
	void RunMainMenu(string input) {
		if(input == "1") {
			int.TryParse(input, out level);
            password = easyPasswords[Random.Range(0, easyPasswords.Length)];
			ShowGame();
		}
		if(input == "2") {
			int.TryParse(input, out level);
            password = mediumPasswords[Random.Range(0, mediumPasswords.Length)];
			ShowGame();
		}
	}

	// Runs whenever an input is left on Screen.Password.
	// Purely the functionality specific to this screen.
	void RunPassword(string input) {
		if(input == password) {
			ShowWinScreen();
		} else {
			ShowGame();
		}
	}

	void ShowGame() {
		// Set Screen
		currentScreen = Screen.Password;

		Terminal.ClearScreen();

		if(password == "") {
				Terminal.WriteLine("You have chosen level " + level + ".");
		} else {
			Terminal.WriteLine("Whoopse! Please try again.");
		}
		
		// Ask for Guess
		Terminal.WriteLine("Your hint is: " + password);
		Terminal.WriteLine("");
		Terminal.WriteLine("Please Enter Your Password:");

	}

	// Displays the win screen, along with the solution.
	void ShowWinScreen() {
		currentScreen = Screen.Win;

		Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("Congratz! You've hacked in!");
		Terminal.WriteLine("The solution was: " + password);
		Terminal.WriteLine("");
		Terminal.WriteLine("Type menu to start again.");
	}

    void ShowLevelReward() {
        switch(level){
            case 1:
                Terminal.WriteLine(@"
                /=\""/=\
               (=(0_0 |=)__
                \_\ _/_/   )
                  /_/   _  /\
                | / |\ || |
                ");

                break;
            case 2:
                Terminal.WriteLine(@"
               \||/
               \||/
             .<><><>.
            .<><><><>.
            '<><><><>'
             '<><><>'
                ");
                break;
        }

    }


	// string jumbleWord() {
	// 	string[] solutionArr = new [] { solution }

	// 	return String.join('', jumbledArr);
	// }


// 	let mixup = function(word) {
//   let res = [];
//   wordArr = word.split('');
//   // For every letter
//   for(var i=0; i<word.length; i++) {

//     // Place letter in random location within word
//     let place = Math.floor(Math.random() * (i + 1));
//     console.log(place, ' + ', wordArr[i]);
//     res.splice(place, 0, wordArr[i]);

//   }
//   // Return word
//   return res.join('');
// }


	// Update is called once per frame
	void Update () {
		
	}
}
