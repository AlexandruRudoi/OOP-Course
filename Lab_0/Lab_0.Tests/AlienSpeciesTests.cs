using Lab_0.Domain;

namespace Lab_0.Tests;

[TestFixture]
    public class AlienSpeciesTests
    {
        [Test]
        public void Classify_ShouldReturnWookie_ForKashyyykHairyTallSpecies()
        {
            var species = new AlienSpecies
            {
                Id = 1,
                IsHumanoid = false,
                Planet = "Kashyyyk",
                Age = 300,
                Traits = new List<string> { "HAIRY", "TALL" }
            };

            // Act
            var classification = species.Classify();

            // Assert
            Assert.That(classification, Is.EqualTo("Star Wars Universe (Wookie)"));
        }

        [Test]
        public void Classify_ShouldReturnEwok_ForEndorShortHairySpecies()
        {
            var species = new AlienSpecies
            {
                Id = 2,
                IsHumanoid = false,
                Planet = "Endor",
                Age = 50,
                Traits = new List<string> { "SHORT", "HAIRY" }
            };

            // Act
            var classification = species.Classify();

            // Assert
            Assert.That(classification, Is.EqualTo("Star Wars Universe (Ewok)"));
        }

        [Test]
        public void Classify_ShouldReturnAsgardian_ForAsgardBlondeTallSpecies()
        {
            var species = new AlienSpecies
            {
                Id = 3,
                IsHumanoid = true,
                Planet = "Asgard",
                Age = 1500,
                Traits = new List<string> { "BLONDE", "TALL" }
            };

            // Act
            var classification = species.Classify();

            // Assert
            Assert.That(classification, Is.EqualTo("Marvel Universe (Asgardian)"));
        }

        [Test]
        public void Classify_ShouldReturnBetelgeusian_ForBetelgeuseExtraArmsExtraHeadSpecies()
        {
            var species = new AlienSpecies
            {
                Id = 4,
                IsHumanoid = true,
                Planet = "Betelgeuse",
                Age = 90,
                Traits = new List<string> { "EXTRA_ARMS", "EXTRA_HEAD" }
            };

            // Act
            var classification = species.Classify();

            // Assert
            Assert.That(classification, Is.EqualTo("Hitchhiker's Universe (Betelgeusian)"));
        }

        [Test]
        public void Classify_ShouldReturnVogon_ForVogsphereGreenBulkySpecies()
        {
            var species = new AlienSpecies
            {
                Id = 5,
                IsHumanoid = false,
                Planet = "Vogsphere",
                Age = 150,
                Traits = new List<string> { "GREEN", "BULKY" }
            };

            // Act
            var classification = species.Classify();

            // Assert
            Assert.That(classification, Is.EqualTo("Hitchhiker's Universe (Vogon)"));
        }

        [Test]
        public void Classify_ShouldReturnElf_ForEarthBlondePointyEarsSpecies()
        {
            var species = new AlienSpecies
            {
                Id = 6,
                IsHumanoid = true,
                Planet = "Earth",
                Age = null,
                Traits = new List<string> { "BLONDE", "POINTY_EARS" }
            };

            // Act
            var classification = species.Classify();

            // Assert
            Assert.That(classification, Is.EqualTo("Lord of the Rings (Elf)"));
        }

        [Test]
        public void Classify_ShouldReturnDwarf_ForEarthShortBulkySpecies()
        {
            var species = new AlienSpecies
            {
                Id = 7,
                IsHumanoid = true,
                Planet = "Earth",
                Age = 100,
                Traits = new List<string> { "SHORT", "BULKY" }
            };

            // Act
            var classification = species.Classify();

            // Assert
            Assert.That(classification, Is.EqualTo("Lord of the Rings (Dwarf)"));
        }

        [Test]
        public void Classify_ShouldReturnUnknown_ForSpeciesWithLowScore()
        {
            var species = new AlienSpecies
            {
                Id = 8,
                IsHumanoid = true,
                Planet = "Unknown Planet",
                Age = 100,
                Traits = new List<string> { "UNKNOWN_TRAIT" }
            };

            // Act
            var classification = species.Classify();

            // Assert
            Assert.That(classification, Is.EqualTo("Unknown Universe"));
        }
    }