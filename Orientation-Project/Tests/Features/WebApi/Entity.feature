Feature: Entity 

Scenario Outline: View a single Entity
	When user sends a request fo a specific entity '<Entity>' with placeName '<PlaceName>'
	Then user should be a able to get the deatils abt the entity with its defined Amenities with code '<Code>'
Examples:
| Entity       | PlaceName                 | Code |
| Tourist      | Jama Masjid               | 200  |
| Accomodation | Holiday Inn               | 200  |
| Food         | Pind Balluchi             | 200  |
| Activities   | Rockshot Paintball Sports | 200  |
| Tourist      | Taj mahal                 | 400  |
| Accomodation | Uday cty palace           | 400  |
| Food         | Cyberhub                  | 400  |
| Activities   | qwerty                    | 400  |
	
Scenario Outline:  View a list of entity of size 3 
	When user sends a request for a specific entity '<Entity>'
	Then user should be able to get the deatils abt the entity with its defined Amenities with code '<Code>' in the size 3
Examples:
| Entity       | Code |
| Tourist      | 200  |
| Accomodation | 200  |
| Food         | 200  |
| Activities   | 200  |



