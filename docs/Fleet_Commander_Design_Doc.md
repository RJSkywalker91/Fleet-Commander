# Star Wars Fleet Commander Game Design Document

## Prototype Status
Everything decided in this document up to this point is prototype-only. All systems, rules, numbers, factions, content, terminology, battlefield layouts, and implementation details are expected to change as the game is tested and refined. Nothing in this document should be treated as final design unless it is later promoted out of prototype status.

## Game Overview
* Elevator Pitch: A Star Wars themed, deckbuilder, combat game where the player utilizes cards to fuel their fight against their enemies.
* Genre: Space Deckbuilder / Auto-battler?
* Player Fantasy: Command Star Wars battles
* Design Pillars
  - Battlefield Control: Players should feel like they are commanding an army
  - Resource Struggle: Players must wisely spend their resources (aka mana) to send out units (aka cards)
  - Chaotic War: Players should feel the ebb and flow tension of battle

## Core Gameplay Loop
Players assume command of a Star Wars faction (e.g. Rebel Alliance, Galactic Empire, Trade Alliance, etc.) by operating as a fleet commander. The screen is a tactical simulation in which fighter squadrons, weapons, shield powerups, etc. are deployed by playing cards. The main resource is "Supplies". X amount of supplies are used to send out units to the battlefield for Y amount of time. (X and Y detailed on the card).

Current prototype: The playable loop is a minimal click-to-deploy slice. A test card is spawned at the start of the scene. Clicking that card plays it, destroys the card object, spawns the linked squadron at a grid cell, and orders the squadron to move to another grid cell.

## Match Structure
### Start of Match
Players start a match with RNG deciding who goes first. Starting resources are supplied, and decks are shuffled then drawn from.

Current prototype: There is no match start sequence yet. The scene starts by spawning one configured test card.

### Gameplay
* Resources refresh (some amount, not known right now)
* Draw 1 card from deck
* Deploy units by spending resources
* Fighters resolve their effects

Current prototype: The player clicks the test card to deploy its linked squadron. There is no resource refresh, deck draw, turn structure, enemy behavior, or fighter effect resolution yet.

### Victory / Defeat
* Victory: Defeat all enemy units OR achieve objective
* Defeat: Lose all ally units OR fail objective

Current prototype: Victory and defeat are not implemented yet.

### Expected Match Length
5-10 minutes

## Battlefield
* Layout: Looks like the various command modules seen in the Star Wars universe
* Positioning: Fighters are positioned in a single "deployed" section. Fighter resolution is determined by speed? (some initiative system)
* Objectives: Defeat all enemy units
* Current prototype: The battlefield is represented by a camera-sized 16 x 9 grid. The grid calculates world-space positions and cell centers from the active orthographic camera. Gizmos draw the grid in the editor.
* Current prototype deployment path: Squadron cards currently spawn their squadron at grid cell (0, 0), then command it to move to grid cell (5, 2).

## Cards
### Card Anatomy
Current prototype: Cards are ScriptableObject definitions with:
* Card type
* Display name
* Supply cost
* Prefab reference

Runtime card instances cache:
* Generated unique ID
* Definition reference
* Card type
* Display name
* Supply cost

Card definitions validate that supply cost is not negative.

### Card Types
Current prototype card types:
* Squadron
* Powerup
* Debuff

Only Squadron cards currently have specialized behavior.

### Drawing
Not implemented yet. The prototype currently spawns one configured test card at scene start rather than drawing from a deck.

### Playing
Current prototype: Cards are played by clicking the card object. The card raises a Played event. The BattleController handles that event. If the card is a Squadron card, it spawns the linked squadron, destroys the card object, and gives the squadron a movement order.

### Discard / Recycling
Not implemented yet. The current prototype destroys the played card object instead of moving it to a discard pile or recycling system.

## Supplies
* Generation: Not implemented yet.
* Maximum: Not implemented yet.
* Costs: Current prototype cards define a supplyCost value. The X Wing Squadron card currently costs 2 supplies. Costs are stored and validated, but they are not yet enforced by a supply pool.

### Resource Decisions
Not implemented yet. Supply costs exist as card data, but the player does not currently spend supplies or make affordability decisions in the prototype.

## Units
### Deployment
Current prototype: Squadrons are spawned from SquadronDefinition assets through a SquadronSpawner. A Squadron card references the SquadronDefinition it should spawn.

### Movement
Current prototype: Squadrons can be ordered to move to a world-space target position. They move using their speed stat over time until they reach the target.

### Targeting
Not implemented yet.

### Combat
Current prototype: Squadrons have health, shields, damage, and speed stats. Damage handling exists, but no attack loop, target selection, or weapon resolution is implemented yet.

### Duration
Not implemented yet. Deployed squadrons currently remain in the scene unless removed by some future system.

### Destruction
Not implemented yet. Squadrons can take damage to shields and hull, but there is no current destruction/death behavior when health reaches 0.

## Combat System
Current prototype: Only the damage model exists. Incoming damage is applied to shields first, then remaining damage is applied to hull health. No automated combat resolution, targeting, initiative, speed ordering, attack timing, or victory/defeat integration exists yet.

## Deckbuilding
### Deck Rules
TBD

### Card Acquisition
TBD

### Deck Construction
TBD

## Factions
Faction Identity
Mechanical Identity

## Game Structure / Progression
* Where does the game start?
* What does the end look like?
* Will there be "campaigns"?

## Presentation
* Camera: Current prototype uses an orthographic camera. The battle grid sizes itself from the camera height and aspect ratio.
* UI: Current prototype uses world objects for cards and mouse clicks for play interaction. No formal UI layer exists yet.
* Battlefield Visualization: Current prototype uses editor gizmos to visualize the 16 x 9 battle grid.
* Audio: Not implemented yet.

## Content
* Cards: Current prototype includes one card asset, X Wing Squadron, with type Squadron and supply cost 2.
* Squadrons: Current prototype includes one squadron asset, X Wing Squadron, with hull integrity 10, damage 3, shields 2, and speed 2.
* Maps: Current prototype uses one SampleScene with the BattleController, BattleGrid, CardSpawner, and SquadronSpawner wired together.
* Encounters: Not implemented yet.

## Prototype / MVP Scope
* 1 battlefield
* 2 factions
* 10-15 cards per faction
* 1 resource
* 3-4 unit archetypes
* 1 victory condition
* No progression
* No card unlocks
* No campaign
* No multiplayer

## Open Design Questions
