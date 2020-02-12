# Pi_dartboard
This project implements a (somewhat crude) way to estimate Pi using Monte-Carlo simulation. 
  
This uses the method discussed in the following article:  
  
Laura Sach, "Whose spline is it anyway?", Raspberry Pi Hello World Magazine, Issue 10, October 2019, pp.16-18 (N.B. Can be found online at https://helloworld.raspberrypi.org/)  
  
The basic concept is to throw notional 'darts' pseudo-randomly at a (also notional) 'dartboard'. Note that in practice we only use a quarter-dartboard of side 1 unit. If we label as 'p' the proportion of darts which fall within radius 1 (or, equivalently unity radius-squared) of the bottom left hand corner, then we can estimate Pi as 4p. Note that if we take the bottom left-hand corner as the coordinate origin, and each dart has horizontal and vertical coordinates x and y respectively, then the distance-squared of each dart from the origin is x^2+y^2. So if this is <1 we say the (quarter) dartboard was 'hit', otherwise 'missed'.  


