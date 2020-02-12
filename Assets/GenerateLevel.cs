using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    /* Current scene index determines difficulty
     *
     * Difficulty determines number of:
     *  - Bosses
     *  - Computers
     *  - Elevators (1 elevator touching all 4 floors, vs 3 elevators)
     *  - Doors (new: They block coffee but not movement. (maybe slow you down just a split second.))
     *  - Split floors
     *
     * Rules:
     *  - Always 1 water cooler
     *  - Always a way to every floor
     *  - Always 4 floors
     *  - Player always starts bottom left
     *  - Number of PCs 2-10 (never decreases)
     *  - Number of Bosses 1-8
     *  - Number of Doors 0-4, max 1 per floor
     *
     * Start:
     * Determine number of items based on difficulty
     *
     *
     * Building floors:
     * 1st (Left) is ALWAYS left wall.
     * 2nd has chance of being a floor or a right wall. (Odds of right wall depends on difficulty modifier)
     *      If 2nd is Right Wall
     *          3rd MUST be a left wall.
     *              Since 3rd is a left wall
     *                  4th has a chance of being floor or right wall.
     *                      If 4th is a right wall
     *                          5th MUST be a left wall
     *                      Else If 4th is a floor
     *                          5th MUST be a floor
     *      Else If 2nd is a floor
     *          3rd may be a floor or right wall
     *              If 3rd is a floor
     *                  4th may be a floor or a right wall
     *                      If 4th is a floor
     *                          5th MUST be a floor
     *                      Else If 4th is a right wall
     *                          5th MUST be a left wall
     *              Else If 3rd is a right wall
     *                  4th MUST be a left wall
     *                      Since 4th is a left wall
     *                          5th MUST be a floor
     * 6th (right) is ALWAYS a right wall
     *
     * 
     */
}
