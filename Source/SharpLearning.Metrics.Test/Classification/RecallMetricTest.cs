﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpLearning.Metrics.Classification;
using System;

namespace SharpLearning.Metrics.Test.Classification
{
    [TestClass]
    public class RecallMetricTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RecallMetric_Not_Binary()
        {
            var targets = new double[] { 0, 1, 1, 2 };
            var predictions = new double[] { 0, 1, 1, 2 };

            var sut = new RecallMetric<double>(1);
            var actual = sut.Error(targets, predictions);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RecallMetric_Not_Different_Lengths()
        {
            var targets = new double[] { 0, 1, 1, 1 };
            var predictions = new double[] { 0, 1, 1, 1, 0 };

            var sut = new RecallMetric<double>(1);
            var actual = sut.Error(targets, predictions);
        }

        [TestMethod]
        public void RecallMetric_No_Error()
        {
            var targets = new double[] { 0, 1, 1 };
            var predictions = new double[] { 0, 1, 1 };

            var sut = new RecallMetric<double>(1);
            var actual = sut.Error(targets, predictions);

            Assert.AreEqual(0.0, actual);
        }

        [TestMethod]
        public void RecallMetric_All_Error()
        {
            var targets = new double[] { 0, 0, 0, 1 };
            var predictions = new double[] { 1, 1, 1, 0 };

            var sut = new RecallMetric<double>(1);
            var actual = sut.Error(targets, predictions);

            Assert.AreEqual(1.0, actual);
        }

        [TestMethod]
        public void RecallMetric_Error()
        {
            var targets = new double[] { 0, 1, 1, 1, 1, 0, 0, 1};
            var predictions = new double[] { 1, 1, 1, 0, 1, 0, 1, 1 };

            var sut = new RecallMetric<double>(1);
            var actual = sut.Error(targets, predictions);

            Assert.AreEqual(0.19999999999999996, actual, 0.0001);
        }
    }
}
