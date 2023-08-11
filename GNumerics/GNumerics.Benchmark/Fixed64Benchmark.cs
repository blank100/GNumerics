using System;
using BenchmarkDotNet.Attributes;
using Gal.Core;

namespace General.Benchmark
{
    [MemoryDiagnoser()]
    public class Fixed64Benchmark
    {
        private Fixed64[] numberList2;
        private double[] numberList3;

        [GlobalSetup]
        public void Setup() {
            numberList2 = new Fixed64[100];
            numberList3 = new double[100];
            for (var i = 0; i < 100; i++) {
                var v = Random.Shared.Next(int.MinValue, int.MaxValue) / 10000d;
                numberList2[i] = v;
                numberList3[i] = v;
            }
        }

        [Benchmark(Baseline = true)]
        public void DoubleArithmetic_Add() {
            var sum = 0d;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList3[i] + numberList3[j];
                }
            }
        }

        [Benchmark()]
        public void Fixed64Arithmetic_Add() {
            var sum = (Fixed64)0;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList2[i] + numberList2[j];
                }
            }
        }

        [Benchmark()]
        public void DoubleArithmetic_Sub() {
            var sum = 0d;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList3[i] - numberList3[j];
                }
            }
        }

        [Benchmark()]
        public void Fixed64Arithmetic_Sub() {
            var sum = (Fixed64)0;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList2[i] - numberList2[j];
                }
            }
        }

        [Benchmark()]
        public void DoubleArithmetic_Mul() {
            var sum = 0d;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList3[i] * numberList3[j];
                }
            }
        }

        [Benchmark()]
        public void Fixed64Arithmetic_Mul() {
            var sum = (Fixed64)0;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList2[i] * numberList2[j];
                }
            }
        }

        [Benchmark()]
        public void DoubleArithmetic_Div() {
            var sum = 0d;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList3[i] / numberList3[j];
                }
            }
        }

        [Benchmark()]
        public void Fixed64Arithmetic_Div() {
            var sum = (Fixed64)0;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList2[i] / numberList2[j];
                }
            }
        }
    }
}