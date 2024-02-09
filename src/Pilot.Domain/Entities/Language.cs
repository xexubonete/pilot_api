using Ardalis.GuardClauses;

namespace Pilot.Domain.Entities
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Diaclect { get; set; }

        // Navigational properties
        public IEnumerable<Referee>? Referees { get; set; }
        public Language(){}
        public Language(Guid id, string diaclect, IEnumerable<Referee> referees)
        {
            Id = id;
            Diaclect = Guard.Against.NullOrEmpty(diaclect, nameof(diaclect));
            Referees = referees;
        }
    }
}