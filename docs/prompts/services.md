# Service & DI Prompt (Oqtane Module)

## Purpose

Use this prompt when creating or modifying **services, repositories, or DI registrations**.

This prompt enforces strict Oqtane client/server boundaries.

---

## Mandatory Context

Before responding, you MUST:

1. Read `.github/copilot-instructions.md`
2. Read `docs/governance/027-rules-index.md`
3. Load all applicable `027x-services-*`, `027x-repositories-*`, and `027x-startup-*` rules
4. Check `docs/ai-decision-timeline.md` for prior decisions

If governance or rules are not visible, STOP and refuse.

---

## Service Rules (Non-Negotiable)

You MUST:

- Respect **client/server separation**
- Register services ONLY via:
  - `IClientStartup` (client)
  - `IServerStartup` (server)
- Keep repositories and DbContexts server-only
- Use explicit interfaces
- Keep services deterministic and testable

You MUST NOT:

- Add or modify `Program.cs` or `Startup.cs`
- Introduce global DI or hosted services
- Register server services on the client
- Introduce background services unless explicitly governed
- Invent abstractions or frameworks

---

## Expected Output

- Interface + implementation (where applicable)
- Correct registration location
- Clear boundary justification

If a required pattern is unclear, REFUSE and propose a rule instead.
