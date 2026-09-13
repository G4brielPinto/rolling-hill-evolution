# Rolling in the Hill — Evolutionary Algorithm Scripts

A source-only academic snapshot of C# scripts used in a Unity-based evolutionary simulation. The
exercise evaluates candidate car configurations and uses genetic-algorithm operations to evolve a
population.

## Included material

The repository includes two milestone snapshots of the core C# scripts:

- CarFitness: simulation fitness integration;
- ParentSelection: tournament-based parent selection;
- Crossover: chromosome crossover logic;
- Mutation: chromosome mutation logic.

The Meta2 snapshot extends the Meta1 work with a revised fitness calculation.

## Deliberately excluded

The original Unity scene, Physics setup, project settings, third-party assets, report, recordings
and compiled artefacts are not included. They were either not present in the material supplied for
this portfolio edition or are not safe to redistribute without a separate asset review.

## Intended integration

The scripts use UnityEngine and the GeneticSharp Unity runner types. To experiment with them:

1. create or obtain a Unity project that provides the matching simulation scene;
2. install compatible GeneticSharp/Unity dependencies;
3. place one matching milestone folder under that Unity project's Assets area;
4. connect the scripts to the scene's CarChromosome evaluation flow.

The repository is not a standalone Unity project and cannot be executed on its own.

## Privacy and sharing

No datasets, credentials, reports, assets or personal contact details are included. The repository
is initially private while it is reviewed for a future public portfolio release.
