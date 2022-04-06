using System.Linq.Expressions;
using AdminPortal.Models;

namespace AdminPortal.Interfaces;

public interface IMongoService<TDocument, TForeign> where TDocument : IDocument, new()
{
    IQueryable<TDocument> GetAll();
    IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TDocument, bool>> filterExpression,
        Expression<Func<TDocument, TProjected>> projectionExpression
    );
}