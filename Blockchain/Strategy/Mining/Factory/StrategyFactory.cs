namespace Blockchain.Strategy.Mining.Factory {
    public static class StrategyFactory {
        public static IStrategy GetStrategy(StrategyEnum strategyEnum, int complexity = 0)
        {
            switch(strategyEnum)
            {
                case StrategyEnum.NoStrategy:
                    return new NoStrategy();
                case StrategyEnum.ProofOfWork:
                    return new ProofOfWorkStrategy(complexity);
            }

            return null;
        }
    }
}