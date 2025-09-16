# OurCity Frontend

## Running app with Docker

Ensure you install [Docker Desktop](https://www.docker.com/products/docker-desktop/).

**I'd also recommend creating Bash/PowerShell scripts to run the following since they are kind of verbose**

### Development Environment (HMR)

To (re)build image, and spin up Docker container in the background

```sh
docker compose up -d --build
```

To clean up the Docker container and it's anonymous volumes

```sh
docker compose down -v
```

### Production Environment

To (re)build image, and spin up Docker container in the background

```sh
docker compose -f docker-compose.production.yml up -d --build
```

To clean up the Docker container

```sh
docker compose -f docker-compose.production.yml down
```

## Running app locally on machine

### Install dependencies

```sh
npm install
```

### Compile and Hot-Reload for Development

```sh
npm run dev
```

### Build for production

To build files

```sh
npm run build
```

To run the built files

```sh
npm run build:preview
```

### Type-Check

```sh
npm run typecheck
```

### Run Tests

Run the tests

```sh
npm run test
```

Run tests on code change (watching for changes)

```sh
npm run test:watch
```

### Linting and Formatting

Run lint

```sh
npm run lint
```

Run lint, and apply fixes

```sh
npm run lint:fix
```

Run format

```sh
npm run format
```

Run format, and apply fixes

```sh
npm run format:fix
```

## Programming Standards (WIP, give suggestions)

- .vue files
  - \<script setup lang="ts"></script>
  - \<template></template>
  - \<style scoped></style>
- kebab-case? camelCase? PascalCase?

## Adding Environment Variables

- Add to:
  - env.d.ts for TypeScript typing
  - .env.example to show example of how it may be used
  - config.ts for usage within files

## TODO: Things to Establish

Here's a list of things that I think whoever the main frontend people can _consider_ looking forward.

- TypeScript?
  - If not, can remove the `lang="ts"` from the \<script setup> from above
- Responsive design
  - Not sure how to do, I tried a little with css 'rem', but if somebody has better suggestion can do that
- Component Library
  - Quick search for Vue component/styling frameworks/libraries
    - Vuetify, Quasar, PrimeVue, Element Plus, Nuxt, Shadcn, Bootstrap, and more
- Folder structure
  - What do you guys like that you have worked with in the past?
  - Obviously, structure can grow with the project, but can think about it
  - Possible examples
    - Slice code into features (e.g. /src/features/reports has /components, /composables, /services, /views)
    - Slice code by technical concern (e.g. /src/components, /src/views, /src/api)
    - Others (e.g. Atomic design)
- What do we want to test
  - Just helper .ts files? Component tests? E2E tests?
- Test Location
  - Should tests be colocated next to the files?
  - Should tests just be in a common "tests" folder?

Also, a list of things/patterns/libraries we may want to look into when needed

- API wrapper
  - e.g. Axios
    - e.g. can add interceptors
      - With interceptors, can log requests, inject data, attach auth tokens (if not doing cookie auth), common error handling, etc
- Query library (e.g. TanStack Query)
  - Can provide built in query states (e.g. return isLoading, isError, etc), caching, background data syncing,
- Global state management (e.g. Pinia)
- Form handler (e.g. FormKit)
- Runtime object validator (e.g. Zod)
- Toast notifications
- Error boundaries
