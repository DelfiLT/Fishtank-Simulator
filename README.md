# Fishtank-Simulator

> This is a simulator to show fish life inside a fishtank, where you can feed them and clean.

## Fishes

> The fishes have a herd algorithm that makes them behave with realistic movements, they check the distance from other fishes and from the fishtank glass.
> Also, in this algorithm we've implemented the food finding.
> Apart from the fish AI, they have three important stats: HP, XP and Age.
> - HP: goes down over time taking into account it's age and, if it is activated, the dirt from the fishtank. It can be restored through feeding, if not, the fish will die.
> - XP: it's incremented once you feed the fish, when it reaches the maximun, the fish can have a child if it finds a couple.
> - Age: increases over time, the fish will grow according to it.

## Food

> We have a food jar that we can use to feed the fishes, when it's activated, the camera will change to the top view. It has a limit of total food.

## Cleaning

> If it's activated, the dirt of the fishtank will increase over time and it can be cleaned with the sponge button.

## Menu Values

> - Fish Quantity: the initial fish quantity.
> - Fish Start Age: the initial age of the fishes, it also afects the newly born
> - Time Scale: the time of the simulation, it affects the HP decrease time, Age increase time and Dirt increase time.
> - Manual Cleaning: the dirt mechanic activated or not, if not, it isn't neccesary to clean the fishtank.

## Stats

> - Initial Fishes
> - Born fishes
> - Death Fishes
> - Oldest Age
> - Youngest Age
> - Current Fishes

## Authors

> - Tomasino Delfina (programming & UI)
> - Ignacio Almada (3D art & UI)
> - Luca Salum (programming & sound)
