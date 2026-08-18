using Task13_XmlDocsExtensionMethods;

/// <summary>
/// Represents a generic in-memory repository for storing and managing entities.
/// </summary>
/// <typeparam name="T">
/// The type of entity stored in the repository.
/// The type must implement IEntity.
/// </typeparam>
/// <example>
/// <code>
/// Repository&lt;Employee&gt; repo = new Repository&lt;Employee&gt;();
/// repo.Add(new Employee(1, "Abood"));
/// </code>
/// </example>
public class Repository<T> where T : IEntity
{
    private readonly List<T> items = new List<T>();


    /// <summary>
    /// Returns all entities that match the specified condition.
    /// </summary>
    /// <param name="condition">
    /// A Func delegate that defines the filtering condition.
    /// </param>
    /// <returns>
    /// A list containing all matching entities.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when condition is null.
    /// </exception>
    /// <example>
    /// <code>
    /// var result = repo.Filter(x => x.Id > 2);
    /// </code>
    /// </example>
    public List<T> Filter(Func<T, bool> condition)
    {
        if (condition == null)
            throw new ArgumentNullException(nameof(condition));

        List<T> result = new List<T>();

        foreach (var item in items)
        {
            if (condition(item))
                result.Add(item);
        }

        return result;
    }


    /// <summary>
    /// Executes an action on every entity stored in the repository.
    /// </summary>
    /// <param name="action">
    /// The Action delegate that will be executed for every entity.
    /// </param>
    /// <returns>
    /// No value is returned.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when action is null.
    /// </exception>
    /// <example>
    /// <code>
    /// repo.ProcessAll(x => Console.WriteLine(x));
    /// </code>
    /// </example>
    public void ProcessAll(Action<T> action)
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action));

        foreach (var item in items)
        {
            action(item);
        }
    }


    /// <summary>
    /// Finds the first entity that matches the specified predicate.
    /// </summary>
    /// <param name="predicate">
    /// The Predicate used to search for an entity.
    /// </param>
    /// <returns>
    /// The first matching entity.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when predicate is null.
    /// </exception>
    /// <exception cref="Exception">
    /// Thrown when no matching entity is found.
    /// </exception>
    /// <example>
    /// <code>
    /// Employee employee = repo.Find(x => x.Id == 1);
    /// </code>
    /// </example>
    public T Find(Predicate<T> predicate)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        foreach (var item in items)
        {
            if (predicate(item))
                return item;
        }

        throw new Exception("Not Found");
    }


    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">
    /// The entity that will be added.
    /// </param>
    /// <returns>
    /// No value is returned.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when entity is null.
    /// </exception>
    /// <example>
    /// <code>
    /// repo.Add(new Employee(1, "Abood"));
    /// </code>
    /// </example>
    public void Add(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        items.Add(entity);
    }


    /// <summary>
    /// Removes an entity from the repository.
    /// </summary>
    /// <param name="entity">
    /// The entity that will be removed.
    /// </param>
    /// <returns>
    /// No value is returned.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when entity is null.
    /// </exception>
    /// <example>
    /// <code>
    /// var employee = repo.GetById(1);
    /// repo.Remove(employee);
    /// </code>
    /// </example>
    public void Remove(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        items.Remove(entity);
    }


    /// <summary>
    /// Gets all entities currently stored in the repository.
    /// </summary>
    /// <returns>
    /// A list containing all stored entities.
    /// </returns>
    /// <example>
    /// <code>
    /// List&lt;Employee&gt; employees = repo.GetAll();
    /// </code>
    /// </example>
    public List<T> GetAll()
    {
        return items;
    }


    /// <summary>
    /// Searches for an entity using its unique Id.
    /// </summary>
    /// <param name="id">
    /// The Id of the entity to search for.
    /// </param>
    /// <returns>
    /// The entity that has the specified Id.
    /// </returns>
    /// <exception cref="Exception">
    /// Thrown when an entity with the specified Id does not exist.
    /// </exception>
    /// <example>
    /// <code>
    /// Employee employee = repo.GetById(1);
    /// </code>
    /// </example>
    public T GetById(int id)
    {
        foreach (var item in items)
        {
            if (item.Id == id)
                return item;
        }

        throw new Exception("Id not found");
    }
}