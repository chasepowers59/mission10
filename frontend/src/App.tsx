import React from 'react';
import Heading from './Heading';
import BowlersTable from './BowlersTable';
import './App.css';

export default function App(): React.ReactElement {
  return (
    <div className="app-container">
      <Heading title="Bowling League — Marlins & Sharks" />
      <BowlersTable />
    </div>
  );
}