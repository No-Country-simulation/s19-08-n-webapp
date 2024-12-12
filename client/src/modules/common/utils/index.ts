export const delay = async (seconds: number): Promise<void> =>
  await new Promise((r) => setTimeout(r, seconds * 1000));
