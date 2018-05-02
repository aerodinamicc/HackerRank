using System;
using Xunit;
using System.IO;
using System.Linq;
using System.Text;

namespace DijkstraShortestReach.Tests
{
    public class DijkstraTests
    {
        /*1
4 4
1 2 24
1 4 20
3 1 3
4 3 12
1
         */
        [Fact]
        public void Success_Test()
        {
            //Arrange
            var adjMatrix = new int[5, 5];
            adjMatrix[1, 2] = 24;
            adjMatrix[2, 1] = 24;
            adjMatrix[1, 4] = 20;
            adjMatrix[4, 1] = 20;
            adjMatrix[3, 1] = 3;
            adjMatrix[1, 3] = 3;
            adjMatrix[4, 3] = 12;
            adjMatrix[3, 4] = 12;
            var startingNode = 1;
            var expectedOutput = "24 3 15";

            //Act
            var output = Dijkstra.FindShortestDistance(adjMatrix, startingNode);
            var actualOutput = string.Join(" ", output);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void SuccessWithTestCaseThree_Test()
        {
            //Arrange
            var expectedOutput =
                @"7 5 6 6 5 7 5 8 8 8 11 7 6 5 8 8 6 7 4 9 9 6 7 7 7 4 9 6 6 8 7 4 10 8 8 3 8 8 9 6 9 6 9 9 7 8 7 8 5 10 8 6 7 6 10 9 12 9 6 8 8 8 8 7 9 5 6 9 6 2 8 9 6 8 4 6 8 5 8 7 2 7 8 7 4 9 8 1 5 9 7 6 6 10 9 8 7 5 8 8 7 5 8 3 8 8 7 10 8 3 8 7 7 9 5 3 8 7 3 8 8 5 7 6 7 10 8 6 10 6 9 7 10 8 10 4 7 7 7 9 6 5 7 5 8 8 8 7 5 8 5 7 6 3 2 10 7 8 8 5 5 2 9 5 6 8 6 5 8 6 5 7 5 11 8 7 6 6 7 4 7 8 10 4 8 8 6 4 6 11 5 8 8 7 9
7 16 7 9 28 10 15 17 11 17 24 11 17 13 14 14 14 13 14 18 17 8 23 10 23 32 11 12 21 13 22 12 14 21 13 8 12 16 4 14 16 13 18 12 6 16 13 11 11 9 10 18 18 11 12 14 18 18 6 3 15 11 16 29 9 11 8 12 10 14 24 10 4 15 5 20 30 4 21 15 6 5 14 5 13 9 16 18 11 13 20 8 19 16 12 16 38
12 10 9 11 12 9 10 13 10 10 11 11 11 10 11 9 10 10 9 11 9 14 11 7 11 11 8 10 15 10 12 18 9 11 10 8 16 13 10 11 10 8 10 12 9 15 13 7 8 11 8 13 10 10 11 9 9 10 12 9 12 11 13 12 10 12 11 10 11 12 8 12 14 11 15 12 11 12 16 11 12 10 10 10 9 9 13 9 10 12 11 11 11 10 10 16 9 9 13 10 11 11 13 11 13 12 10 12 11 7 8 12 11 9 10 6 12 12 7 14 10 10 14 10 10 10 10
10 10 8 11 10 10 11 12 7 8 10 9 8 9 10 9 8 11 11 10 9 11 9 8 8 10 8 8 11 6 11 8 9 10 7 8 9 8 9 8 8 5 12 7 12 7 8 9 11 10 11 8 9 10 10 10 2 6 11 11 7 8 10 9 8 11 11 8 8 8 9 9 7 10 6 7 9 7 8 10 8 9 12 9 11 9 10 11 11 12 12 12 8 9 8 10 10 11 9 7 12 5 9 8 9 4 7 9 11 7 11 7 12 5 5 9 9 7 10 10 15 8 11 9 8 10 10 11 10 10 12 9 10 9 10 11 10 9 11 10 7 7 10 10 9 6 9 6 6 7 10 8 12 11 8 10 8 10 10 9 9 7 11 9 10 8 9 7 11 8 7 9 11 8 7 11 9 9 12 9 8 7 12 12 5 10 10 11 10 13 10 8 9 9 10 10 11
2 3 6 6 11 5 4 4 13 4 3 3 4 2 3 3 4 9 6 6 3 6 6 4 5 5 9 3 1 3 5 3 11 5 8 6 5 3 5 4 3 3 5 3 2 4 4 5 7 6 5 3 4 4 12 3 4 5 4 7 2 4 3 7 3 3 4 4 3 9 5 1 3 2 4 8 1 6 3 4 4 3 8 4 8 11 4 3 3 3 4 6 6 4 4 9 5 3 4 3 6 3 3 2 7 1 5 4 5 4 5 1 5 5 4 4 2 2 2 4 8 6 5 2 1 1 6 3 9 8 3 4 7
7 7 8 5 3 6 7 9 6 5 5 7 9 6 6 7 8 9 7 6 8 4 7 5 5 6 7 6 10 6 7 6 4 6 5 5 2 5 5 5 13 10 4 6 1 6 6 6 6 4 6 6 6 5 4 6 5 5 6 5 5 4 7 6 2 7 5 8 4 3 4 7 6 6 6 6 7 5 4 10 5 8 6 4 4 6 4 6 4 7 3 6 4 5 5 6 6 6 5 5 7 5 7 3 9 7 5 6 4 3 5 7 6 4 2 5 4 7 4 5 6 7 9 6 7 4 7 5 6 5 7 7 5 5 6 6 5 6 6 4 7 6 2 5 5 8 4 7 5 6 7 7 6 5 7 8 7 6 4 6 8 5 5 3 8 7 8 7 6 6 7 13 5 5 8 6 7 3 6 3 8 3 5";

            using (var reader = new StreamReader(@"../../Files/testCase3.txt"))
            {
                var iterations = int.Parse(reader.ReadLine());

                var actualOutput = new StringBuilder();

                for (int i = 0; i < iterations; i++)
                {
                    var count = reader.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                    var nodesCount = count[0];
                    var edgesCount = count[1];

                    var adjMatrix = new int[nodesCount + 1, nodesCount + 1];
                    for (int j = 1; j < edgesCount + 1; j++)
                    {
                        var line = reader.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                        Dijkstra.ReadInput(adjMatrix, line);
                    }

                    var startingNode = int.Parse(reader.ReadLine());
                    var output = Dijkstra.FindShortestDistance(adjMatrix, startingNode);

                    actualOutput.AppendLine(string.Join(" ", output));
                }

                actualOutput.Length -= 2;
                Assert.Equal(expectedOutput, actualOutput.ToString());
            }
        }

        [Fact]
        public void SuccessWithTestCaseTwo_Test()
        {
            //Arrange
            var expectedOutput = @"20 25 25 68 86 39 22 70 36 53 91 35 88 27 30 43 54 74 41
9 8 8 8 12 7 15 8 4 1 12 9 7 10 4 10 10 4 1 7 12 7 11 12 15 10 5 11 6 7 9 11 9 7 7 14 5 13 6 8 10 7 4 9 3 5 5 9 13 1 8 11 4 9 6 7 7 8 11 6 10 7 8 9 13 9 12 8 3 5 7 15 6 10 11 5 11
154 90 186 190 178 114 123 -1 -1 123 -1 104 -1 -1 -1 207 134 123 98 155 -1 198 68 90 170 135 -1 103 145 -1 54 111 163 173 115 87 159 75 -1 94 102 -1 76 67 167 138 216 -1 172 102 212 163 103 112 -1 182 49 145 92 -1 -1 194 -1 182 -1 201 96 -1 85 121 108 161 130 100 120 -1 -1 118 215 92 156 162 163 168 71 110 -1 -1 190 217 100 105 178
13 30 17 33 16 9 31 34 14 20 21 19 24 34 27 42 15 16 19 23 18 21 11 21 28 15 15 45 18 26 17 20 16 28 27 16 22 21 18 21 34 14 26 27 11 23 17 24 27 22 19 18 21 17 17 22 14 20 12 27 21 10 42 10 25 19 22
3 6 8 11 7 12 10 18 4 8 3 6 12 1 2 10 1 8 5 6 9 9 8 17 11 12 8
3 4 5 3 4 5 5 4 4 7 6 4 1 4 5 5 5 4 5 6 5 6 4 5 3 5 5 6 2 6 3 3 6 5 3 6 3 2 6 4 1 6 3 4 5 6 7 7 3 6 3 5 3 5 4 7 4 4 6 4 5 5 5 4 2 2 3 6 4 6 4 4 5 4 6 3 5 5 4 4 4 2 1 3 3 3 2";

            using (var reader = new StreamReader(@"../../Files/testCase2.txt"))
            {
                var iterations = int.Parse(reader.ReadLine());

                var actualOutput = new StringBuilder();

                for (int i = 0; i < iterations; i++)
                {
                    var count = reader.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                    var nodesCount = count[0];
                    var edgesCount = count[1];

                    var adjMatrix = new int[nodesCount + 1, nodesCount + 1];
                    for (int j = 1; j < edgesCount + 1; j++)
                    {
                        var line = reader.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                        Dijkstra.ReadInput(adjMatrix, line);
                    }
                    
                    var startingNode = int.Parse(reader.ReadLine());
                    var output = Dijkstra.FindShortestDistance(adjMatrix, startingNode);

                    actualOutput.AppendLine(string.Join(" ", output));
                }

                actualOutput.Length -= 2;
                Assert.Equal(expectedOutput, actualOutput.ToString());
            }
        }
    }
}
