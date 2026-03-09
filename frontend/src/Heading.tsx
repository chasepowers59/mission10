type Props = { title: string };

export default function Heading({ title }: Props): React.ReactElement {
  return <h1>{title}</h1>;
}