import { useEffect, useState } from 'react';
import type { Bowler } from './types';

export default function BowlersTable(): React.ReactElement {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function load() {
      try {
        setLoading(true);
        const res = await fetch('/api/bowlers');
        if (!res.ok) {
          console.error('Server error:', res.status, res.statusText);
          setBowlers([]);
          return;
        }
        const data = (await res.json()) as Bowler[]; // since we declared Bowler as list above, we recieve as an array too
        setBowlers(data || []); // update our array with the new data we got in the reponse
      } catch (err) {
        console.error('Fetch error', err);
        setBowlers([]);
      } finally {
        setLoading(false);
      }
    }

    load(); // call the function above to actually get the data from db
  }, []);

  if (loading) return <div>Loading bowlers…</div>;
  if (bowlers.length === 0) return <div>No bowlers found (Marlins or Sharks).</div>;

  return (
    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Team</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip</th>
          <th>Phone</th>
        </tr>
      </thead>
      <tbody>
        {bowlers.map((b, i) => (
          <tr key={b.Id ?? i}>
            <td>
              {b.firstName ?? ''} {b.middleInitial ? b.middleInitial + ' ' : ''}{b.lastName ?? ''}
            </td>
            <td>{b.teamName ?? ''}</td>
            <td>{b.address ?? ''}</td>
            <td>{b.city ?? ''}</td>
            <td>{b.state ?? ''}</td>
            <td>{b.zip ?? ''}</td>
            <td>{b.phone ?? ''}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}