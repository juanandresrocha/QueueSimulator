	/* Juan Andrés Rocha - A01228101
	 * Diego Noé Vargas - A0122
	 * Noel Murillo - A0122
	 * 
	 * Quantitative Methods Final Project - EM2017
	 * 
	 * This class includes the logic functionality of the Queueing Simulator.
	 * Important values:
	 * m is the number of open channels.
	 * lambda is the arrivals' rate.
	 * miu is the average service rate in each channel.
	 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour {

	/* Factorial function:
	 * Receives a number n and calculates and returns its factorial
	 */
	static double factorial(int n){
		double fact = n;
		if (n == 0) {
			fact = 1;
			return fact;
		} else {
			for (int i = n-1; i>0; i--) {
				fact = fact * i;
			}
			return fact;
		}
	}

	/* ZeroProbability function:
	 * Receives the m, miu and lambda values and calculates the probability of having
	 * zero clients in the system.
	 */

	static double zeroProbability(double m, double miu, double lambda){
		double probzero = 1;
		double sum = 0;
		double helper = lambda / miu;
		//Sum
		for(int n = 0; n<m;n++){
			sum = sum + ((1/factorial(n))*(System.Math.Pow(helper, n)));
		}

		//Main operation
		probzero = probzero/(sum + ((1 / factorial (System.Convert.ToInt32 (m))) * System.Math.Pow (helper, m) * ((m * miu) / ((m * miu) - lambda))));
		return probzero;
	}

	/* AverageClients function:
	 * Receives the m, miu and lambda values and calculates the average quantity of 
	 * clients or users in the system.
	 */ 

	static double averageClients(double m, double miu, double lambda){
		double helper = lambda / miu;
		double l = (lambda * miu * System.Math.Pow (helper, m)) / (factorial (System.Convert.ToInt32 (m - 1)) * System.Math.Pow (m * miu - lambda, 2));
		l = l * zeroProbability (m, miu, lambda);
		l = l + helper;
		return l;
	}

	/* AverageTime function:
	 * Receives the m, miu and lambda values and calculates the average time the 
	 * users will be in the system.
	 */
	static double averageTime(double m, double miu, double lambda){
		double w = averageClients (m, miu, lambda) / lambda;
		return w;
	}

	/* AverageClientsInLine function:
	 * Receives the m, miu and lambda values and calculates the average quantity of 
	 * clients or users waiting to be served.
	 */ 
	static double averageClientsInLine(double m, double miu, double lambda){
		double lq = averageClients (m, miu, lambda) - (lambda / miu);
		return lq;
	}

	/* AverageTimeInLine function:
	 * Receives the m, miu and lambda values and calculates the average time the 
	 * users will be in the line.
	 */
	static double averageTimeInLine(double m, double miu, double lambda){
		double wq = averageClientsInLine (m, miu, lambda) / lambda;
		return wq;
	}

	/* UsingRate function:
	 * Receives the m, miu and lambda values and calculates the using rate of the system. 
	 */ 
	static double usingRate(double m, double miu, double lambda){
		double ur = lambda / (m * miu);
		return ur;
	}

	// Use this for initialization
	void Start () {

		//Testing functions
		double zero = zeroProbability(2,3,2);
		print (zero);
		double l = averageClients (2, 3, 2);
		print (l);
		double w = averageTime (2, 3, 2);
		print (w);
		double lq = averageClientsInLine (2, 3, 2);
		print (lq);
		double wq = averageTimeInLine (2, 3, 2);
		print (wq);
		double ur = usingRate (2, 3, 2);
		print (ur);
	}

	// Update is called once per frame
	void Update () {

	}
}
